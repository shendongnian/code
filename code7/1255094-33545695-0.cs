    public sealed partial class MyPage : Page
    {
        public List<String> myList { get; set; }
        int selectedItem = -1;
        public MyPage()
        {
            this.InitializeComponent();
            myList = new List<string>()
            {
                "hello",
                "this",
                "is",
                "me"
            };
            Application.Current.Suspending += App_Suspending;
            this.Loaded += MyPage_Loaded;
        }
        private void MyPage_Loaded(object sender, RoutedEventArgs e)
        {
            MyListView.SelectedIndex = selectedItem;
        }
        ...
        public void SetUpUI(int prevSelectedIndex)
        {
            selectedItem = prevSelectedIndex;
        }
    }
