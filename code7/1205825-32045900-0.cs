    public partial class MainWindow : Window
    {
        public List<string> Test = new List<string>() { "test", "someothertext" };
        public MainWindow()
        {
            InitializeComponent();
            treeView.ItemsSource = Test;
            var Source = CollectionViewSource.GetDefaultView(treeView.ItemsSource);
            string search_text = "test";
            Source.Filter = item =>
            {
                return item.ToString().Contains(search_text);
            };
        }
    }
