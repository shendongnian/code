    // in the global section put any data you may make available elsewhere
    private var _engine;
    public Engine => _engine;
    
    public override bool FinishedLaunching(UIApplication app, NSDictionary options)
    {
        /*
         * Do whatever init needs to happen here, if you need to make this
         * available elsewhere, ensure you have properties or accessors,
         * as above.
         */
        _engine = new MyEngine();
        return true;
    }
