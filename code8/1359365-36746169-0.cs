    namespace WindowsFormsApplication2
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            private void Form1_Resize(object sender, EventArgs e)
            {
                HideWindow();
            }
            private void Form1_Load(object sender, EventArgs e)
            {
                HideWindow();
            }
            private void HideWindow()
            {
                if (this.Visible == true)
                {
                    if (this.WindowState == FormWindowState.Minimized)
                    {
                        this.Hide();
                    }
                }
            }
        }
    }
