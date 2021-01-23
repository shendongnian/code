    protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
    {
        if (e.Uri.ToString().Contains("/target"))
        {
            Frame parentFrame = (Frame) Parent;
            var cacheSize = parentFrame.CacheSize;
            parentFrame.CacheSize = 0;
            parentFrame.CacheSize = cacheSize;
        }
        base.OnNavigatingFrom(e);
    }
