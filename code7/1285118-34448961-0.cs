    public partial class Form1 : Form
    {
        public const int WM_HOTKEY = 0x0312;
        public const int MOD_NOREPEAT = 0x4000;
        [DllImport("user32")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            RegisterHotKey(this.Handle, 1, MOD_NOREPEAT, 0x76); 
            // Here 0x76 means F7 
            RegisterHotKey(this.Handle, 2, MOD_NOREPEAT, 0x77);
        }
        protected override void WndProc(ref Message m)
        {
            if(m.Msg == WM_HOTKEY)
                switch (m.WParam.ToInt32())
                {
                    case 1:
                        // Function that you want to send data to dota
                        break;
                    case 2:
                        // Function that you want to send data to dota
                        break;
                }
            base.WndProc(ref m);
        }
    }
