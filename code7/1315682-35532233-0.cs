    private static string _pageData = "";
    public static void MyFunction(string url)
    {
        var th = new Thread(() =>
        {
            var br = new WebBrowser();
            br.DocumentCompleted += PageLoaded;
            br.Navigate(url);
            Application.Run();
        });
        th.SetApartmentState(ApartmentState.STA);
        th.Start();
        while (th.IsAlive)
        {
        }
        MessageBox.Show(_pageData);
    }
    static void PageLoaded(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
        var br = sender as WebBrowser;
        if (br.Url == e.Url)
        {
             _pageData = br.DocumentText;
            Application.ExitThread();   // Stops the thread
         }
        }
    }
