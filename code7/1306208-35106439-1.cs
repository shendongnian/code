    public partial class BorderForm : Form
    {
        public BorderForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            BorderColor = Color.DarkSlateGray;
        }
        private const int hWidth = 12;        // resize handle width
        private const int bWidth = 28;        // border width
        public Color BorderColor { get; set;  }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        protected override void OnPaint(PaintEventArgs e)
        {
            // draw the border..
            using (Pen pen = new Pen(BorderColor, bWidth))
                e.Graphics.DrawRectangle(pen, ClientRectangle);
            // now maybe draw a title text..
            base.OnPaint(e);
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x84) // Trap WM_NCHITTEST
            {  
                Point pos = new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16);
                pos = PointToClient(pos);
                bool isTop = pos.Y <= hWidth;
                bool isBottom = pos.Y >= ClientSize.Height - hWidth;
                bool isRight = pos.X >= ClientSize.Width - hWidth;
                bool isLeft = pos.X <= hWidth;
                m.Result = (IntPtr)1;
                if (isTop) m.Result = 
                           isLeft ? (IntPtr)13 : isRight ? (IntPtr)14 : (IntPtr)12;
                else if (isBottom) m.Result = 
                     isLeft ? (IntPtr)16 : isRight ? (IntPtr)17 : (IntPtr)15;
                else if (isLeft) m.Result = (IntPtr)10;  
                else if (isRight) m.Result = (IntPtr)11;
                if ( m.Result != (IntPtr)1) return;
            }
            base.WndProc(ref m);
        }
    }
