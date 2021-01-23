    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        internal void CaptureMouseMove(Point location)
        {
            if (panel1.RectangleToScreen(panel1.ClientRectangle).Contains(location))
            {
                button1.Visible = true;
                Console.WriteLine(location + "in " + panel1.RectangleToScreen(panel1.ClientRectangle));
            }
            else
            {
                button1.Visible = false;
                Console.WriteLine(location + "out " + panel1.RectangleToScreen(panel1.ClientRectangle));
            }
        }
        internal bool Form1_ProcessMouseMove(Message m)
        {
            Point pos = new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16);
            Control ctr = Control.FromHandle(m.HWnd);
            if (ctr != null)
            {
                pos = ctr.PointToScreen(pos);
            }
            else
            {
                pos = this.PointToScreen(pos);
            }
            this.CaptureMouseMove(pos);
            return false;
        }
        private MouseMoveMessageFilter mouseMessageFilter;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // add filter here
            this.mouseMessageFilter = new MouseMoveMessageFilter();
            this.mouseMessageFilter.TargetForm = this;
            this.mouseMessageFilter.ProcessMouseMove = this.Form1_ProcessMouseMove;
            Application.AddMessageFilter(this.mouseMessageFilter);
        }
        protected override void OnClosed(EventArgs e)
        {
            // remove filter here
            Application.RemoveMessageFilter(this.mouseMessageFilter);
            base.OnClosed(e);
        }
        private class MouseMoveMessageFilter : IMessageFilter
        {
            public Form TargetForm { get; set; }
            public Func<Message, bool> ProcessMouseMove;
            public bool PreFilterMessage(ref Message m)
            {
                if (TargetForm.IsDisposed) return false;
                //WM_MOUSEMOVE
                if (m.Msg == 0x0200)
                {
                    if (ProcessMouseMove != null)
                       return ProcessMouseMove(m);
                }
                return false;
            }
        }
    }
