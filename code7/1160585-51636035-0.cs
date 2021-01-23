    public ChromiumWebBrowser browser;
    private void Form1_Load(object sender, EventArgs e)
    {
        var newsettings = new BrowserSettings();
        CefSettings Settings = new CefSettings();
        Settings.CachePath = "test";  //always set the cachePath, else this wont work
        //add an if statement to initialize the settings once. else the app is going to crash
         if (CefSharp.Cef.IsInitialized == false)
             CefSharp.Cef.Initialize(Settings);
        var browser = new ChromiumWebBrowser(url) { Dock = DockStyle.Fill };
         toolStripContainer1.ContentPanel.Controls.Add(browser);
    }
