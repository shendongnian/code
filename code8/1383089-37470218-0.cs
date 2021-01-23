            public MainWindow()
        {
            InitializeComponent();
            List = new List<Person>();
            List.Add(new Person("John", "xxx", 20));
            List.Add(new Person("Dimitri", "yyy", 17));
            LP.ItemsSource = List;
        }
        private void DoubleClick(object sender, MouseButtonEventArgs e)
        {
            Window1 win2 = new Window1();
            win2.Show();
        }
