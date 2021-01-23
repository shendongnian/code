    public MainWindow()
        {
            InitializeComponent();
            KeyDown += MainWindow_KeyDown;
        }
        void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control)
            {
                if (e.Key == Key.V)
                {
                }
            }
        }
