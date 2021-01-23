        public MainWindow()
        {
            InitializeComponent();
            ContentRendered += MainWindow_ContentRendered;
        }
        void MainWindow_ContentRendered(object sender, EventArgs e)
        {
            MessageBox.Show("Hello");
        }
