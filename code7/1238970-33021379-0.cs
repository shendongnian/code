    public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
    
            private void notifyIcon1_Click(object sender, EventArgs e)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
            }
    
            private void Form1_ResizeBegin(object sender, EventArgs e)
            {
                if (WindowState == FormWindowState.Minimized)
                {
                    this.Hide();
                }
            }
    
        }
