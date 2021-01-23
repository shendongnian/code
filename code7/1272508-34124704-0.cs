    private async Task CaptureWebView()
    {
        int width;
        int height;
        var originalWidth = WebView.ActualWidth;
        var originalHeight = WebView.ActualHeight;
        var widthString = await WebView.InvokeScriptAsync("eval", new[] { "document.body.scrollWidth.toString()" });
        var heightString = await WebView.InvokeScriptAsync("eval", new[] { "document.body.scrollHeight.toString()" });
        if (!int.TryParse(widthString, out width))
        {
            throw new Exception("Unable to get page width");
        }
        if (!int.TryParse(heightString, out height))
        {
            throw new Exception("Unable to get page height");
        }
        // resize the webview to the content
        WebView.Width = width;
        WebView.Height = height;
        var brush = new WebViewBrush();
        brush.SetSource(WebView);
        Painter.Width = width;
        Painter.Height = height;
        Painter.Fill = brush;
    }
