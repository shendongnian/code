    protected void Capture(object sender, EventArgs e)
    {
        string url = "www.google.com";
        Thread thread = new Thread(delegate()
        {
            using (WebBrowser browser = new WebBrowser())
            {
                browser.ScrollBarsEnabled = false;
                browser.AllowNavigation = true;
                browser.Navigate(url);
                browser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(DocumentCompleted);
                while (browser.ReadyState != WebBrowserReadyState.Complete)
                {
                    System.Windows.Forms.Application.DoEvents();
                }
            }
        });
        thread.SetApartmentState(ApartmentState.STA);
        thread.Start();
        thread.Join();
    }
     
    private void DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
        WebBrowser browser = sender as WebBrowser;
           //do what do you want
    }
