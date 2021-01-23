    bool navigating= false;    
    private void webBrowser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
    {
        navigating= true;
        SetCurrentValue(UrlProperty, webBrowser.Url);
        navigating= false;
    }
    private static void UrlPropertyChangedCallback(DependencyObject sender, DependencyPropertyChangedEventArgs e)
    {
        if (!navigating)
            (sender as WebView).webBrowser.Url = e.NewValue as Uri;
    }
