    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private readonly ObservableCollection<Item> _items = new ObservableCollection<Item>();
        public ObservableCollection<Item> Items
        {
            get { return _items; }
        }
        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new AppContext())
            {
                var items = context.Items.ToArray();
                // Clears the item source then re-add all items.
                Items.Clear();
                Array.ForEach(items, Items.Add);
            }
        }
    }
