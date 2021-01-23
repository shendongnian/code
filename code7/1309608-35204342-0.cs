        public MainWindow()
        {
            InitializeComponent();
            FillDataGrid();
        }
        private void FillDataGrid()
        {
            ObservableCollection<YourModel> coll = new ObservableCollection<YourModel>();
            for (int start = 0; start < 10; start++)
            {
                coll.Add(new YourModel(){TitleField="Title " +  
                start.ToString());                                
            }
            dataGrid.ItemsSource = coll;
            comboBox.DisplayMemberPath = "TitleField";
            comboBox.ItemsSource = coll;
        }
       
        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {            
            var dataGrid = e.Source as DataGrid;
            var currentIndex = dataGrid.Items.IndexOf(dataGrid.CurrentItem);            
            comboBox.SelectedIndex= currentIndex;
        }
