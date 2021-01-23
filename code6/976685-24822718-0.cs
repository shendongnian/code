    static void Main(string[] args)
    {
        Task t = new Task(() =>
        {
            WebCore.Initialize(new WebConfig(), true);
            WebView browser = WebCore.CreateWebView(1024, 768, WebViewType.Offscreen);
            browser.DocumentReady += browser_DocumentReady;
            browser.Source = new Uri("https://www.google.ru/");
            WebCore.Run();
        });
        t.Start();
        Console.ReadLine();
    }
    static void browser_DocumentReady(object sender, UrlEventArgs e)
    {
        Console.WriteLine("DocumentReady");
    }
