    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    
        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            HwndSource source = PresentationSource.FromVisual(this) as HwndSource;
            source.AddHook(WndProc);
        }
    
        private const int WM_SYSCOMMAND = 0x0112;
        private const int SC_MONITORPOWER = 0xf170;
    
        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            if (msg == WM_SYSCOMMAND)
            {
                if (wParam.ToInt32() == SC_MONITORPOWER)
                {
                    switch (lParam.ToInt32())
                    {
                        case -1:
                            this.listBox1.Items.Add("display is powering on");
                            break;
    
                        case 2:
                            this.listBox1.Items.Add("display is being shut off");
                            break;
                    }
                }
            }
    
            return IntPtr.Zero;
        }
    
    }
