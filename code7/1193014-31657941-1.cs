    Button buton = new Button();
        public MainWindow()
        {
            InitializeComponent();            
            buton.Click += Buton_Click;
            grid.Children.Add(buton);
        }
        private void Buton_Click(object sender, RoutedEventArgs e)
        {
            buton.Visibility = Visibility.Hidden;
        }
