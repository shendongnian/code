    public MainPage()
    {
        this.InitializeComponent();
        DataContext = MyList;
    }
    private ObservableCollection<MyClass> MyList = new ObservableCollection<MyClass>();
    private void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
    {
        MyList.Add(new MyClass("Hello", "World"));
    }
