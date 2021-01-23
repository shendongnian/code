    public partial class MainWindow : Window
       {
           public MainWindow()
        {
            InitializeComponent();
        }
        public static ObservableCollection<SomeClass> GetItems()
        {
            ObservableCollection<SomeClass> some_inner_object_list = new ObservableCollection<SomeClass>();
            some_inner_object_list.Add(new SomeClass(1, "data_grid_1-String1", "data_grid_1-Text1"));
            some_inner_object_list.Add(new SomeClass(2, "data_grid_1-String2", "data_grid_1-Text2"));
            some_inner_object_list.Add(new SomeClass(3, "data_grid_1-String3", "data_grid_1-Text3"));
            some_inner_object_list.Add(new SomeClass(4, "data_grid_1-String4", "data_grid_1-Text4"));
       
            return some_inner_object_list;
        }
        private void data_grid_1_Loaded(object sender, RoutedEventArgs e)
        {
            data_grid_1.ItemsSource = GetItems();
        }
        private void data_grid_1_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if (e.AddedCells.Count == 0) return;
            var currentCell = e.AddedCells[0];
            if (currentCell.Column ==
                data_grid_1.Columns[1])
            {
                data_grid_1.BeginEdit();
            }
        }
    }
