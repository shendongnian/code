    public partial class Form1 : Form
    {
        Form2 f2 = new Form2();
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (f2 == null || f2.IsDisposed)
            {
                f2 = new Form2();
                f2.Show();
            }
            else 
            {
                if (f2.WindowState == FormWindowState.Minimized)
                {
                    f2.WindowState = FormWindowState.Normal;
                }
                f2.Show();
                f2.BringToFront();
            }
        }
    }
