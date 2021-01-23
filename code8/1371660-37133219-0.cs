        public MainWindow()//***ctor of Window
        {
            InitializeComponent();
            PopulateListView();
        }
        private void PopulateListView()
        {
            IList<FooClass> someValues = new List<FooClass>();
            for (int i = 0; i < 10; i++)
            {
                someValues.Add(new FooClass() { IsChecked=true});
            }
            listBox.ItemsSource = someValues;
        }
