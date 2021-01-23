    public partial class MainWindow : Window
    {
        public ObservableCollection<ItemContainer> items { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            items = new ObservableCollection<ItemContainer>();
            items.Add(new ItemContainer() { containerItems = new List<string>() { "Item1", "Item2", "Item3" } });
            items.Add(new ItemContainer() { containerItems = new List<string>() { "Item4", "Item5", "Item6" } });
            this.DataContext = this;
        }
        public static T FindAncestorOrSelf<T>(DependencyObject obj)
            where T : DependencyObject
        {
            while (obj != null)
            {
                T objTest = obj as T;
                if (objTest != null)
                    return objTest;
                obj = VisualTreeHelper.GetParent(obj);
            }
            return null;
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListViewItem lvItem = FindAncestorOrSelf<ListViewItem>(sender as ComboBox);
            ListView listView = ItemsControl.ItemsControlFromItemContainer(lvItem) as ListView;
            int index = listView.ItemContainerGenerator.IndexFromContainer(lvItem);
            Console.WriteLine(index.ToString());
        }
    }
