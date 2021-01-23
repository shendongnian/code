    public partial class MainWindow : Window
    {
        public class Item
        {
            public string Text { get; set; }
            public Visibility ShowOverlap { get; set; }
        }
        public MainWindow()
        {
            InitializeComponent();
            List<Item> items = new List<Item>();
            items.Add(new Item() { Text = "Test1", ShowOverlap = Visibility.Hidden });
            items.Add(new Item() { Text = "Test2", ShowOverlap = Visibility.Visible });
            items.Add(new Item() { Text = "Test3", ShowOverlap = Visibility.Hidden });
            DataContext = items;
        }
    }
