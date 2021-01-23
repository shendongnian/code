    public override void ViewDidLoad()
    {
        base.ViewDidLoad();
    
        webView.LoadRequest(new NSUrlRequest(new NSUrl("https://xamarin.com")));
    
        webView.LoadFinished += (sender, e) =>
        {
            if (webView.IsLoading)
            {
                return;
            }
            var html = webView.EvaluateJavascript("document.documentElement.outerHTML");
        };
    }
