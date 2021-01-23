    private WebBrowser _webBrowser;
    
    public SomeControl()
    {
        InitializeComponent();
        
        // Initialize the WebBrowser
        _webBrowser = new WebBrowser();
        webContainer.Children.Add(_webBrowser);
    }
    public void Navigate(string url)
    {
        _webBrowser.Navigate(url);
    }
    // Call this when the parent panel is closed.
    public void Close()
    {
        WebBrowser webBrowser = _webBrowser; // Local web browser
        webContainer.Children.Clear(); // Web browser is not part of the Windnow.
        _webBrowser = null; // reference of the browser from the control is null, we have only local reference.
        
        bool isDone = false;
        this.Dispatcher.BeginInvoke(new Action(() =>
        {
            webBrowser.Navigate("about:blank");
            webBrowser.Navigated += (sender, eventArgs) => {
                isDone = true;
            };
            // Wait until browser navigates on about:blank page.
            Task waitTask = new Task(new Action(() =>
            {
                while (!isDone)
                {
                    System.Threading.Thread.Sleep(200);
                }
            }));
            waitTask.Start();
            
            // Wait until the navigation is done - wait the task.
            this.Dispatcher.Wait(waitTask);
            webBrowser.Dispose();
            webBrowser = null;
        }));
    }
