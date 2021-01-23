    private void SetEmbedUrl(string embedUrl)
    {
        myWebView.NavigateToString("<iframe id=\"iFrameEmbedTile\" src =\""
            + embedUrl +
            "\" style=\"width: 400px; height: 405px\"></iframe>" +
            "<script src=\"ms-appx-web:///postActionLoadTile.js\"></script>");
    }
    private void myWebView_FrameDOMContentLoaded(WebView sender, WebViewDOMContentLoadedEventArgs args)
    {
        await myWebView.InvokeScriptAsync("postActionLoadTile", new[] { myTextBox.Text, "400", "400" });
    }
