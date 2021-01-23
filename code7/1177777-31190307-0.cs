    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private const int MOD_ALT = 0x0001;
        private const int MOD_CONTROL = 0x0002;
        private const int MOD_SHIFT = 0x0004;
        private const int MOD_WIN = 0x0008;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);
        private void button1_Click(object sender, EventArgs e)
        {
            bool result = RegisterHotKey(this.Handle, 1001, MOD_CONTROL | MOD_SHIFT, (int)Keys.N);
            if (result)
            {
                UnregisterHotKey(this.Handle, 1001);
            }
            string msg = result ? " was NOT " : " WAS ";
            MessageBox.Show("The Ctrl-Shift-N combination" + msg + "already registered on your system.");
        }
    }
