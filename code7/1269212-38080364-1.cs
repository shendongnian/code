           public frmProjectDetail()
        {
            InitializeComponent();
            browser = new ChromiumWebBrowser("http://www.google.com.tr")
            {
                Dock = DockStyle.Fill,
            };
            //browser.RegisterJsObject("bound", bound);
            splitContainerControl2.Panel1.Controls.Add(browser);
            browser.LoadingStateChanged += OnLoadingStateChanged;
            browser.ConsoleMessage += OnBrowserConsoleMessage;
            browser.StatusMessage += OnBrowserStatusMessage;
            browser.TitleChanged += OnBrowserTitleChanged;
            browser.AddressChanged += OnBrowserAddressChanged;
            browser.MouseClick += Browser_MouseClick;
            var obj = new BoundObject(browser);
            obj.HtmlItemClicked += Obj_HtmlItemClicked;
            obj.ItemResponse += Obj_ItemResponse;
            browser.RegisterJsObject("bound", obj);
            browser.FrameLoadEnd += obj.OnFrameLoadEnd;
            browser.DialogHandler = new SilentDialogHandler();
        }
        
        private void Obj_HtmlItemClicked(object sender, HtmlItemClickedEventArgs e)
        {
            this.InvokeOnUiThreadIfRequired(() => setMemoText("Tıklanan Element: " + e.Id));
        }
