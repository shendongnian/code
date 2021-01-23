    public class AsyncWebView
    {
        public static SynchronizationContext _synchronizationContext;
        private readonly WebView _webView;
        public AsyncWebView()
        {
            _synchronizationContext = SynchronizationContext.Current;
            _webView = WebCore.CreateWebView(1024, 900);
        }
        public async Task Navigate(String url)
        {
            Debug.WriteLine("Navigating");
            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
            FrameEventHandler handler = (sender, args) =>
            {
                Debug.WriteLine(args.Url);
                if (!_webView.IsNavigating && !_webView.IsLoading)
                    tcs.SetResult(true);
            };
            _webView.LoadingFrameComplete += handler;
            _synchronizationContext.Send(SetWebViewSource, url);
            await tcs.Task;
            _webView.LoadingFrameComplete -= handler;
            Debug.WriteLine("Done");
        }
        private void SetWebViewSource(object url)
        {
            _webView.Source = new Uri((string)url);
        }
    }
