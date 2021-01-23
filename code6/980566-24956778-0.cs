    public partial class UserControl1 : System.Windows.Forms.DateTimePicker
    {
        private Bitmap bmp = null;
        public UserControl1()
        {
            InitializeComponent();
            bmp = new Bitmap(5, 5);
            bmp.SetPixel(2, 2, Color.Red); //Placeholder, Load the bitmap here
        }
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == 0xf) //WM_PAINT message
            {
                Graphics g = Graphics.FromHwnd(m.HWnd);
                g.DrawImage(bmp, ClientRectangle.Width - 8, 3);
                g.Dispose();
            }
        }
    }
 
