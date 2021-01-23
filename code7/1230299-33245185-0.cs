    public ObservableCollection<clsPivotData> Items { get; set; }
            
    public ObservableCollection<clsPivotData> lstOffer { get; set; }
    public ObservableCollection<clsPivotData> lstServices { get; set; }
    public ObservableCollection<clsPivotData> lstInfo { get; set; }
    // Constructor
      public MainViewModel()
      {
        this.Items = new ObservableCollection<clsPivotData>();
        LoadData();
        lstOffer = Items.Where(o => o.Name == "offer").FirstOrDefault().PivotItems;
        lstServices = Items.Where(o => o.Name == "service").FirstOrDefault().PivotItems;
        lstInfo = Items.Where(o => o.Name == "info").FirstOrDefault().PivotItems;    }
