    public partial class MainWindow
    {
        public List<MyItem> Items { get; private set; }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            Items = new List<MyItem>
            {
                new MyItem {Text = "Item 1", ImageSource = "/image1.png"},
                new MyItem {Text = "Item 2", ImageSource = "/image2.png"}
            };
        }
    }
    public class MyItem
    {
        public string Text { get; set; }
        public string ImageSource { get; set; }
    }
