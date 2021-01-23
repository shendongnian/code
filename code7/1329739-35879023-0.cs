    WebView wb = new WebView();
    wb.NavigationStarting += A_NavigationStarting;
    
    private void A_NavigationStarting(WebView sender, WebViewNavigationStartingEventArgs args)
    {
        args.Cancel = true;
        var rm = new HttpRequestMessage(HttpMethod.Post, args.Uri);
        rm.Headers.Add("User-Agent", "UserAgentString");
        sender.NavigateWithHttpRequestMessage(rm);
    }
