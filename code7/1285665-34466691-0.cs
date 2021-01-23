    public ICommand LoadDataCommand { get; set; }
    public StartPage()
    { 
        ...
        BindingContext = this;
        LoadDataCommand = new Command(RefreshData);
        RefreshData();
    }
    private async void RefreshData()
    {
        Items = new ObservableCollection<SomeItem>();  // Load Data and set
        IsRefreshing = false;
    }
    public ObservableCollection<SomeItem> Items { get; set; }
