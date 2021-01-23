    public IFormRegionFactory Factory { get; set; }
    public FormRegion OutlookFormRegion { get; set; }
    public object OutlookItem { get; private set; }
    public FormRegionManifest Manifest { get; private set; }
    public event EventHandler FormRegionShowing;
    public event EventHandler FormRegionClosed;
