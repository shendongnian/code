    using System;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void textBox1_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnOK_Click(sender, e);
                    MessageBox.Show("My message here");
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    btnOK_Click(sender, e);
                    MessageBox.Show(((char)Keys.Escape).ToString());
                }
            }
    
            private void btnOK_Click(object sender, EventArgs e)
            {
                MessageBox.Show("Test");
            }
        }
    }
