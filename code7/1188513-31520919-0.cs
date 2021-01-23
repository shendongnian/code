    public partial class Form1 : Form, IMessageFilter
    {
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_LBUTTONDOWN = 0x201;
        private const int WM_LBUTTONDBLCLK = 0x0203;
        private const int WM_RBUTTONDOWN = 0x0204;
        private const int WM_RBUTTONDBLCLK = 0x0206;
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }
        void Form1_Load(object sender, EventArgs e)
        {
            Application.AddMessageFilter(this);
        }
        public bool PreFilterMessage(ref Message m)
        {
            switch(m.Msg)
            {
                case WM_KEYDOWN:
                    Control ctl = this.ActiveControl;
                    if ((ctl != null) && ctl.Equals(this.WebBrowser))
                    {
                        return true;
                    }
                    break;
                case WM_LBUTTONDOWN:
                case WM_LBUTTONDBLCLK:
                case WM_RBUTTONDOWN:
                case WM_RBUTTONDBLCLK:
                    Rectangle rc = this.WebBrowser.RectangleToScreen(new Rectangle(new Point(0, 0), this.WebBrowser.ClientSize));
                    return rc.Contains(Cursor.Position);
            }
            
            return false;
        }
    }
