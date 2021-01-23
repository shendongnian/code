    public class Item
    {
        public int ItemId { get; set; }
        public int ItemCode { get; set; }
        public string ItemDescription { get; set; }
        public double ItemSellingPrice { get; set; }
        public int QTY { get; set; }
    }
    public class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var items = new List<Item>();
            _dataGrid.ItemsSource = items;
            var totalAmount = items.Sum(i => i.ItemSellingPrice);
            _label.Content= totalAmount;
        }
    }
