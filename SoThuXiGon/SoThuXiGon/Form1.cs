using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace SoThuXiGon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

      

        private void ListBox_MouseDown(object sender, MouseEventArgs e)
        {
            ListBox lb = (ListBox)sender;
            int index = lb.IndexFromPoint(e.X, e.Y);

            if (index != -1)
                lb.DoDragDrop(lb.Items[index].ToString(),
                              DragDropEffects.Copy);
        }

        private void ListBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.Move;
        }

        private void lstDanhSach_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                ListBox lb = (ListBox)sender;
                lb.Items.Add(e.Data.GetData(DataFormats.Text));
            }
        }

        private void Save(object sender, EventArgs e)
        {
            // Mo tap tin
            StreamWriter write = new StreamWriter("danhsachthu.txt");

            if (write == null) return;

            foreach (var item in lstDanhSach.Items)
                write.WriteLine(item.ToString());

            write.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StreamReader reader = new StreamReader("thumoi.txt");

            if (reader == null) return;

            string input;
            while ((input = reader.ReadLine()) != null)
            {
                lstThuMoi.Items.Add(input);
            }
            reader.Close();

            using (StreamReader rs = new StreamReader("danhsachthu.txt"))
            {
                input = null;
                while ((input = rs.ReadLine()) != null)
                {
                    lstDanhSach.Items.Add(input);
                }
            }
        }
    }
}
