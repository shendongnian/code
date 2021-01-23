    public MainWindow()
    {
        InitializeComponent();
        worksorderColumn.ItemsSource = efacsdb.GetOrderItems();
        gridTimesheets.ItemsSource = timesheetdb.GetTimesheetItems();
    }
