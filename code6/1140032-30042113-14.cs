    public sealed partial class MainPage : Page
    {
        public ObservableCollection<MyClass> MyList { get; set; }
        public FilteredObservableCollection<MyClass> yesList { get; set; }
        public FilteredObservableCollection<MyClass> noList { get; set; }
        public FilteredObservableCollection<MyClass> emptyList { get; set; }
        public MainPage()
        {
            this.InitializeComponent();
            MyList = new ObservableCollection<MyClass>();
            yesList = new FilteredObservableCollection<MyClass>(MyList, item => item.Status == "Yes");
            noList = new FilteredObservableCollection<MyClass>(MyList, item => item.Status == "No");
            emptyList = new FilteredObservableCollection<MyClass>(MyList, item => item.Status == "" && item.Date.Date == DateTime.Now.Date);
            DataContext = this;
        }
        private void AddYes_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            MyList.Add(new MyClass("Yes", DateTime.Now));
        }
        private void AddNo_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            MyList.Add(new MyClass("No", DateTime.Now));
        }
        private void AddEmpty_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            MyList.Add(new MyClass("", DateTime.Now));
        }
        private void Delete_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            MyList.Remove((MyClass)AllElementsList.SelectedItem);
        }
        private void Toggle_Click(object sender, RoutedEventArgs e)
        {
            MyClass oldItem = (MyClass)AllElementsList.SelectedItem,
                newItem = new MyClass(oldItem.Status == "Yes" ? "No" : (oldItem.Status == "No" ? "Yes" : ""), oldItem.Date);
            MyList[AllElementsList.SelectedIndex] = newItem;
        }
    }
