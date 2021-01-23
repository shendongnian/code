    public partial class MainWindow : Window
    {
        public ObservableCollection<ItemContainer> items { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            items = new ObservableCollection<ItemContainer>();
            items.Add(new ItemContainer() { containerItems = new List<string>() { "Item1", "Item2", "Item3" } });
            items.Add(new ItemContainer() { containerItems = new List<string>() { "Item1", "Item2", "Item3" } });
            this.DataContext = this;
        }
        public static DependencyObject GetParent(DependencyObject obj)
        {
            if (obj == null)
                return null;
            ContentElement ce = obj as ContentElement;
            if (ce != null)
            {
                DependencyObject parent = ContentOperations.GetParent(ce);
                if (parent != null)
                    return parent;
                FrameworkContentElement fce = ce as FrameworkContentElement;
                return fce != null ? fce.Parent : null;
            }
            return VisualTreeHelper.GetParent(obj);
        }
        public static T FindAncestorOrSelf<T>(DependencyObject obj)
            where T : DependencyObject
        {
            while (obj != null)
            {
                T objTest = obj as T;
                if (objTest != null)
                    return objTest;
                obj = GetParent(obj);
            }
            return null;
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListViewItem lv = FindAncestorOrSelf<ListViewItem>(sender as ComboBox);
            ListViewItem item = (ListViewItem)lv;
            ListView listView = ItemsControl.ItemsControlFromItemContainer(item) as ListView;
            int index = listView.ItemContainerGenerator.IndexFromContainer(item);
            Console.WriteLine(index.ToString());
        }
    }
