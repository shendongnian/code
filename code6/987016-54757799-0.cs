    public partial class Form1 : Form
    {
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);
        public Form1()
        {
            InitializeComponent();
            c_scroll.ScrollSlide += C_scroll_ScrollSlide;
            
        }
        private void C_vScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            const int LVM_SCROLL = (0x1000 + 20);
            SendMessage(c_listView_show.Handle, LVM_SCROLL, 0, e.NewValue - e.OldValue);
        }
    }
