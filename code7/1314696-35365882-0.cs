    private BitmapImage currentWall = new BitmapImage();
    public BitmapImage CurrentWallpaper
    {
        get { return currentWall; }
        set { currentWall= value; OnPropertyChanged("CurrentWallpaper"); }
    }
