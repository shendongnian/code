    public partial class MainWindow : Window
    {
        public bool AllowClose { get; set; }
        private WindowInteropHelper _helper;
        public MainWindow()
        {
            InitializeComponent();
            Loaded += (sender, e) =>
            {
                _helper = new WindowInteropHelper(this);
                _helper.EnsureHandle();
                SystemEvents.SessionEnding += (s1, e1) =>
                {
                    if (e1.Reason == SessionEndReasons.SystemShutdown)
                    {
                        Dispatcher.InvokeAsync(() => MessageBox.Show("attempting to block shutdown"));
                        e1.Cancel = true;
                    }
                };
                if (!ShutdownBlockReasonCreate(_helper.Handle, "Testing Stack Overflow Block Reason"))
                {
                    MessageBox.Show("Failed to create shutdown-block reason. Error: "
                        + Marshal.GetExceptionForHR(Marshal.GetLastWin32Error()).Message);
                }
            };
        }
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            if (!AllowClose)
            {
                e.Cancel = true;
                ShutdownBlockReasonDestroy(_helper.Handle);
            }
            base.OnClosing(e);
        }
        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public extern static bool ShutdownBlockReasonCreate([In]IntPtr hWnd, [In] string pwszReason);
        [DllImport("user32.dll", SetLastError = true)]
        public extern static bool ShutdownBlockReasonDestroy([In]IntPtr hWnd);
    }
