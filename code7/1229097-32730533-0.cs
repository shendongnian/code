    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += Form2_Load;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            SetNumbersOnlyTextBox(this.textBox1);
        }
        public const int GWL_STYLE = (-16);
        public const int ES_NUMBER = 0x2000;
        [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        public void SetNumbersOnlyTextBox(TextBox TB)
        {
            SetWindowLong(TB.Handle, GWL_STYLE, GetWindowLong(TB.Handle, GWL_STYLE) | ES_NUMBER);
        }
    }
