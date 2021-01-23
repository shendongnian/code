    public MainWindow()
    {
       Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
       InitializeComponent();
       PopulateCollection();
    }
    private void PopulateCollection()
    {
        ObservableCollection<FooClass> fooColl = new ObservableCollection<FooClass>();
        for (int i = 0; i <= 10; i++)
        {
            fooColl.Add(new FooClass() { Description=i.ToString(), SomeDate=DateTime.Now});
        }
        dataGrid.ItemsSource = fooColl;
    }
