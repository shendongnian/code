    private async void WebView_LoadCompleted(object sender, NavigationEventArgs e)
    {
        WebView webView = sender as WebView;
        string html = await webView.InvokeScriptAsync(
            "eval",
            new string[] { "document.documentElement.outerHTML;" });
        // TODO: Do something with the html ...
        System.Diagnostics.Debug.WriteLine(html);
    }
