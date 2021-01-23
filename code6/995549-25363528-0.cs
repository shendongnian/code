    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication3
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                StringBuilder builder = new StringBuilder();
    
                for (int i = 0; i < 10; i++)
                {
                    builder.Append(i);
                    listBox1.Items.Add(builder);
                    builder.Clear();
                }
    
                for (int i = 0; i < 10; i++)
                {
                    builder.Append(i);
                    listBox2.Items.Add(builder.ToString());
                    builder.Clear();
                }
            }
    
            private void button2_Click(object sender, EventArgs e)
            {
                string a = listBox1.GetItemText(listBox1.SelectedItem.ToString());
                string b = listBox1.SelectedItem.ToString();
                string c = listBox1.GetItemText(listBox1.SelectedItem);
                string d = listBox2.GetItemText(listBox2.SelectedItem.ToString());
                string f = listBox2.SelectedItem.ToString();
                string g = listBox2.GetItemText(listBox2.SelectedItem);
                MessageBox.Show("1:" + a + b + c + "\r\n2: " + d+ f + g);
            }
        }
    }
