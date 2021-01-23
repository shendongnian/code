    public MainWindow()
        {
            InitializeComponent();
            // set position of window on screen
            this.Left = SystemParameters.PrimaryScreenWidth - this.Width;
            this.Top = SystemParameters.WorkArea.Bottom - this.Height;
        }
