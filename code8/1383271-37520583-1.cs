    private ObservableCollection<TestItem> itemcollection = new ObservableCollection<TestItem>();
    
    public MainPage()
    {
        this.InitializeComponent();
    }
    
    protected override async void OnNavigatedTo(NavigationEventArgs e)
    {
        StorageFolder picLib = KnownFolders.PicturesLibrary;
        var picfiles = await picLib.GetFilesAsync();
        foreach (var pic in picfiles)
        {
            BitmapImage bmp = new BitmapImage();
            IRandomAccessStream stream = await pic.OpenReadAsync();
            bmp.SetSource(stream);
            itemcollection.Add(new TestItem { ImageItem = bmp });
        }
    }
    
    private void MasterListView_ItemClick(object sender, ItemClickEventArgs e)
    {
        var clickedItem = (TestItem)e.ClickedItem;
    
        if (AdaptiveStates.CurrentState == NarrowState)
        {
            Frame.Navigate(typeof(DetailPage), clickedItem);
        }
    }
