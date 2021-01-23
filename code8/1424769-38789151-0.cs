    <WebView NavigationStarting="OnNavigationStarting" />
    void OnNavigationStarting(WebView sender, WebViewNavigationStartingEventArgs args)
    {
        var url = args.Uri; 
        if(url.Scheme == "myprotocol") 
        {
            // navigating to my custom uri, cancelling...
            args.Cancel = true;
        }
    }
