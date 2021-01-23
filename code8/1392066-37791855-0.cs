    public class CustomWebView : WebView
    {
        public CustomWebView()
        {
            Navigating += OnShouldLoad;
        }
        private void OnShouldLoad(object sender, WebNavigatingEventArgs e)
        {
            if (!e.Url.StartsWith("runcode") || !e.Url.Contains(":"))
                return;
            var urlInfo = e.Url.Split(':');
            switch (urlInfo[1])
            {
