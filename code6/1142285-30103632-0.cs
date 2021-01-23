        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }
        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            StartCall();
        }
        ArrayList formArray = new ArrayList();
        Window1 vd;
        public void StartCall()
        {
            vd = new Window1();
            formArray.Add(vd);
            vd.Owner = this; //magic here :)
            vd.Show();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ((Window1)(formArray[0])).Show();
        }
