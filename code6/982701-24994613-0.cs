    public void Initialize()
    {
        regionManager
            .AddToRegion(“TabRegion”, new FirstView())
            .AddToRegion(“TabRegion”, new SecondView());
    }
