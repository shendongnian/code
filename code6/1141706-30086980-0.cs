    public MainWindow()
    {
        // At design time (in your XAML), initialize to the "Loading..." state
        InitializeComponent()
    }
    private async void Window_Loaded(object sender, RoutedEventArgs e)
    {
        ClassA hello = new ClassA();
        await hello.ConnectAsync();
        //List will be used as Source for DataGrid
        List<object> DataGridViewSource List<object>();
        //use the instance of hello to get some Data from the WebService. 
        List<int> objectIds = new List<int>();
        objectIds = hello.GetObjectIds("LDAPQuery");
        foreach (int id in objectIds)
        {
            var tmpObj = await hello.GetObjectByIdAsync(id);
            DataGridViewSource.Add(tmpObj);
        }
        //do binding to DataGrid
    }
