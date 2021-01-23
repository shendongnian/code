    private async void webView_NavigationCompleted(WebView sender, WebViewNavigationCompletedEventArgs args)
    {
        MyWebViewRectangle.Fill = await GetWebViewBrush(webView);
        MyPrintPages.ItemsSource = await GetWebPages(webView, new Windows.Foundation.Size(842, 595));
    }
