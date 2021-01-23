    using System;
    using System.Windows.Forms;
    
    namespace CustomFile
    {
        public partial class myUserControl : UserControl
        {
            public myUserControl()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                MessageBox.Show("Button Clicked");
            }
    
            private void pictureBox1_Click(object sender, EventArgs e)
            {
                MessageBox.Show("Image Clicked");
    
            }
    
            private void checkBox1_CheckedChanged(object sender, EventArgs e)
            {
                if (!checkBox1.Checked)
                    pictureBox1.Visible = false;
                else
                    pictureBox1.Visible = true;
            }
        }
    }
