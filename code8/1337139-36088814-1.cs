        public ObservableCollection<Button> testOC { get; set; }
        public ObservableCollection<Button> testOC1 { get; set; }
        public ObservableCollection<Button> testOC2 { get; set; }
 
        public MainWindow()
        {
            InitializeComponent();
            testOC = new ObservableCollection<Button>();
            testOC1 = new ObservableCollection<Button>();
            testOC2 = new ObservableCollection<Button>();
            for (int i = 0; i < 20; i++)
            {
                var content = "Test Stuff " + i;
                Button btn = new Button();
                btn.Content = content;
                testOC.Add(btn);
                Button btn1 = new Button();
                btn1.Content = content;
                testOC1.Add(btn1);
                Button btn2 = new Button();
                btn2.Content = content;
                testOC2.Add(btn2);
            }
            ListCollectionView view1 = new ListCollectionView(testOC1);
            ListCollectionView view2 = new ListCollectionView(testOC2);
            view1.Filter = Filter1;
            view2.Filter = Filter2;
            leftGrid.ItemsSource = testOC;
            MiddleGrid.ItemsSource = view1;
            rightGrid.ItemsSource = view2;
        }
