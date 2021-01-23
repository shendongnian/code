    public MainPage()
    {
        this.InitializeComponent();
    }
    public ObservableCollection<LocationPicture> Pictures
    {
        get { return _pictures; }
        set { _pictures = value; }
    }
    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        CreateDummyList();
    }
    public void CreateDummyList()
    {
        List<LocationPicture> pictures = new ObservableCollection<LocationPicture>();
        pictures.Add(new LocationPicture { ImageUri = "Images/1.jpg", LocationName = "location" });
        pictures.Add(new LocationPicture { ImageUri = "Images/2.jpg", LocationName = "location" });
        pictures.Add(new LocationPicture { ImageUri = "Images/3.jpg", LocationName = "location" });
        _pictures = pictures;       
        this.DataContext = this;
    }
