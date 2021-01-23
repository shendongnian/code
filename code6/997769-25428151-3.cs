    public partial class MyUserControl : UserControl
    {
        private TransparentWindow label;
        private TransparentWindow pic;
        public MyUserControl()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            label = new TransparentWindow(label1);
            pic = new TransparentWindow(pictureBox1);
        }
    }
    class TransparentWindow : NativeWindow
    {
        public TransparentWindow(Control control)
        {
            this.AssignHandle(control.Handle);
        }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == (int)WindowsMessage.WM_NCHITTEST)
            {
                m.Result = (IntPtr)(-1);//Transparent
                return;
            }
            base.WndProc(ref m);
        }
    }
