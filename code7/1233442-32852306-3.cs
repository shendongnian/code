    public class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SetClipboardViewer(IntPtr hWndNewViewer);
        public const int WM_DRAWCLIPBOARD = 0x0308;
        private void Form1_Load(object sender, EventArgs e)
        {
            SetClipboardViewer(this.Handle);
        }
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg != WM_DRAWCLIPBOARD)
                return;
            //Code To handle Clipboard change event
        }
    }
