    private async void OnButtonClick(object sender, RoutedEventArgs e)
    {
        int width;
        int height;
        // get the total width and height
        var widthString = await saveWebView.InvokeScriptAsync("eval", new[] { "document.body.scrollWidth.toString()" });
        var heightString = await saveWebView.InvokeScriptAsync("eval", new[] { "document.body.scrollHeight.toString()" });
    
        if (!int.TryParse(widthString, out width))
        {
            throw new Exception("Unable to get page width");
        }
        if (!int.TryParse(heightString, out height))
        {
            throw new Exception("Unable to get page height");
        }
    
        // resize the webview to the content
        saveWebView.Width = width;
        saveWebView.Height = height;
    
        WebViewBrush b = new WebViewBrush();
        b.SourceName = "saveWebView";
        b.Redraw();
        saveWebViewBrush.Fill = b;
    }
