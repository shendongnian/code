    string selectitem = null;
    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        if (e.Parameter != null)
        {
            string getdata = e.Parameter.ToString();
            selectitem = getdata;
        }
        if (selectitem.Equals("Item1"))
        {
            pivotcontrol.SelectedIndex = 0;
        }
        else if (selectitem.Equals("Item2"))
        {
            pivotcontrol.SelectedIndex = 1;
        }
        else
        {
            pivotcontrol.SelectedIndex = 2;
        }
    }
    public PivotPage()
    {  
        this.InitializeComponent();
    }
    private void item_back(object sender, RoutedEventArgs e)
    {
        this.Frame.Navigate(typeof(MainPage));
    }
