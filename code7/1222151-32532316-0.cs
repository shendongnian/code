    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace WindowsFormsApplication4
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            private void button1_Click(object sender, EventArgs e)
            {
                Clipboard.SetText("Box 1: " + textBox1.Text + "\r\nBox 2: " + textBox2.Text + "\r\nBox 3: " +textBox3.Text);
            }
            private void highlightbox(object sender, EventArgs e)
            {
                textBox1.BackColor = Color.LightGray;
                textBox2.BackColor = Color.LightGray;  
            }
            private void unhighlightbox(object sender, EventArgs e)
            {
                textBox1.BackColor = Color.Empty;
                textBox2.BackColor = Color.Empty;
            }
        }
    }
