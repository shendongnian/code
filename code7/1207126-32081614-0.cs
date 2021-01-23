    using System;
    using System.Windows.Forms;
    
    namespace _3ConcatenatedTextBoxes
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void textBox1_TextChanged(object sender, EventArgs e)
            {
                changeTextBox4();
            }
    
            private void textBox2_TextChanged(object sender, EventArgs e)
            {
                changeTextBox4();
            }
    
            private void textBox3_TextChanged(object sender, EventArgs e)
            {
                changeTextBox4();
            }
    
            private void changeTextBox4()
            {
                textBox4.Text = textBox1.Text + textBox2.Text + textBox3.Text;
            }
        }
    }
