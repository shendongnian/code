    public MainViewModel()
    {
        ZoomLevels = new List<ZoomLevel>()
        {
            new ZoomLevel { Name = "normal", ZoomLevelValue = 1 },
            new ZoomLevel { Name = "large", ZoomLevelValue = 1.2 },
            new ZoomLevel { Name = "xxl", ZoomLevelValue = 1.4 },
        };
        // here
        ZoomLevel = ZoomLevels.FirstOrDefault(
            z => z.ZoomLevelValue == Settings.Default.ZoomLevelValue);
    }
    public List<ZoomLevel> ZoomLevels { get; private set; }
