     public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                this.WindowState= FormWindowState.Maximized;
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                if (this.WindowState == FormWindowState.Maximized)
                    this.WindowState = FormWindowState.Normal;
             
                else if (this.WindowState == FormWindowState.Normal)
                    this.WindowState = FormWindowState.Maximized;
            }
         
        }
