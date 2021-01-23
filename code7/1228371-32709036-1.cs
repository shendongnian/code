    public class myWebViewClient : WebViewClient
    {
        public override void OnPageFinished(WebView view, string url)
        {
            base.OnPageFinished(view, url);
            Console.WriteLine("OnPageFinished for url : " + url + " at : " + DateTime.Now);
        }
     }
