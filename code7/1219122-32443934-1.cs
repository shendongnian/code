        public class ItemData
        {
            public int ItemHeight { get; private set; }
            public int ItemWidth { get; private set; }
            public string ItemText { get; private set; }
            public ItemData(int itemHeight, int itemWidth, string itemText)
            {
                ItemHeight = itemHeight;
                ItemWidth = itemWidth;
                ItemText = itemText;
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            MyListBox.ItemsSource = BuildItems();
        }
        private System.Collections.IEnumerable BuildItems()
        {
            yield return new ItemData(20, 200, "First");
            yield return new ItemData(40, 300, "Second");
            yield return new ItemData(60, 100, "Third");
        }
