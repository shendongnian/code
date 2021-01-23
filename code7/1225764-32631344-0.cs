    protected override void PrepareViewFirst(Frame rootFrame)
    {
       RegisterNavigationService(rootFrame);
    }
    public INavigationService RegisterNavigationService(Frame rootFrame, bool treatViewAsLoaded = false)
    {
        if (rootFrame == null)
            throw new ArgumentNullException("rootFrame");
        var frameAdapter = new CachingFrameAdapter(rootFrame, treatViewAsLoaded);
        container.RegisterInstance(typeof(INavigationService), null, frameAdapter);
        return frameAdapter;
    }
