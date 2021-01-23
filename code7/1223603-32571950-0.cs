    public partial class form1 : Form, IMessageFilter 
    {
        public form1()
        {
            InitializeComponent();
            Application.AddMessageFilter(this);
        }
        private bool UpDepressed = false;
        private bool RightDepressed = false;
        private const int WM_KEYDOWN = 0x100;
        private const int WM_KEYUP = 0x101;
        public bool PreFilterMessage(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_KEYDOWN:
                    if ((Keys)m.WParam == Keys.Up)
                    {
                        UpDepressed = true;
                    }
                    else if ((Keys)m.WParam == Keys.Right)
                    {
                        RightDepressed = true;
                    }
                    break;
                case WM_KEYUP:
                    if ((Keys)m.WParam == Keys.Up)
                    {
                        UpDepressed = false;
                    }
                    else if ((Keys)m.WParam == Keys.Right)
                    {
                        RightDepressed = false;
                    }
                    break;
            }
            timer1.Enabled = (UpDepressed && RightDepressed);
            label1.Text = timer1.Enabled.ToString();
            return false;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToString("ffff");
        }
    }
