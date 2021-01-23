    public sealed partial class MainPage : Page
    {
        private ObservableCollection<int> myItems = new ObservableCollection<int> { 1, 2, 3, 4, 5, 6, 7, 8 };
        public ObservableCollection<int> MyItems
        {
            get { return myItems; }
            set { myItems = value; }
        }
        public MainPage()
        {
            this.InitializeComponent();
            DataContext = this;
            MyItems.CollectionChanged += myControl.Items_CollectionChanged;
        }
        protected override Size MeasureOverride(Size availableSize)
        {
            myControl.CurrentWidth = Math.Min(availableSize.Height, availableSize.Width);
            return base.MeasureOverride(availableSize);
        }
        private void Button_Click(object sender, RoutedEventArgs e) => MyItems.Add(3);
    }
