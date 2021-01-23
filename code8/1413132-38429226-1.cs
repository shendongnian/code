           public MainWindow()
        {
            InitializeComponent();
            ListToBind = new ObservableCollection<DataModel>
            {
                new DataModel { Header = "header 1",
                    Collection = new List<string>{"Item 1","Item 2", "Item 3"}},
                new DataModel { Header = "header 2",
                    Collection = new List<string>{"Item 1","Item 2", "Item 3"}},
                new DataModel { Header = "header 3",
                    Collection = new List<string>{"Item 1","Item 2", "Item 3"}},
             
            };
            this.DataContext = this;
            var para1 = new Form1();
            var check = ListBox1;
       }
         
