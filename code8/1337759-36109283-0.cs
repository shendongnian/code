        .
        .
        .
        var client = new MyWebViewClient();
        WebView web = FindViewById<WebView>(Resource.Id.webView1);
        web.SetWebViewClient(client);
        .
        .
        .
    class MyWebViewClient : WebViewClient {
        public override void OnReceivedHttpAuthRequest(WebView view, HttpAuthHandler handler, string host, string realm) {
            handler.Proceed(username, password);
        }
    }
