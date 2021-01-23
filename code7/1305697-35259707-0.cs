    [ClassInitialize]
    public static void initializeTest(TestContext context)
    {
         Playback.Initialize();
         var _bw = BrowserWindow.Launch(new Uri("http://www.bing.com"));
         proc = _bw.Process;
        _bw.CloseOnPlaybackCleanup = false;
    }
