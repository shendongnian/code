    public partial class MainWindow : Window
    {
        private readonly ObservableCollection<MyItem> _myItems = new ObservableCollection<MyItem>();
        public MainWindow()
        {
            InitializeComponent();
            myList.ItemsSource = _myItems;
            _myItems.Add(new MyItem { Name = "name", ID = "id", LastMessage = "last message" });
            _myItems[0].LastMessage = "new message";
        }
    }
