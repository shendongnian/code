    //Create ChromiumWebBrowser
    _wb = new ChromiumWebBrowser(Urls.HOME)
    {
        Dock = DockStyle.Fill,
        Location = new System.Drawing.Point(0, 22),
        MinimumSize = new System.Drawing.Size(20, 20),
        Size = new System.Drawing.Size(1280, 900),
        TabIndex = 8
    };
    //Add ChromiumWebBrowser to the Browser Panel and add events
    pnlBrowser.Controls.Add(_wb);
    var requestHandler = new RequestHandler();
    _wb.RequestHandler = requestHandler;
