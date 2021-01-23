    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // The 'Host' part of the URI for the ms-local-stream protocol needs to be a combination of the package name
            // and an application-defined key, which identifies the specific resolver, in this case 'MyTag'.
            Uri url = webView.BuildLocalStreamUri("MyTag", "index.html");
            StreamUriWinRTResolver myResolver = new StreamUriWinRTResolver();
            // Pass the resolver object to the navigate call.
            webView.NavigateToLocalStreamUri(url, myResolver);
        }
        private void webView_ScriptNotify(object sender, NotifyEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("ScriptNotifyValue: " + e.Value);
        }
    }
    public sealed class StreamUriWinRTResolver : IUriToStreamResolver
    {
        public IAsyncOperation<IInputStream> UriToStreamAsync(Uri uri)
        {
            if (uri == null)
            {
                throw new Exception();
            }
            string path = uri.AbsolutePath;
            // Because of the signature of the this method, it can't use await, so we
            // call into a seperate helper method that can use the C# await pattern.
            return GetContent(path).AsAsyncOperation();
        }
        private async Task<IInputStream> GetContent(string path)
        {
            // We use app's local folder as the source
            try
            {
                Uri localUri = new Uri("ms-appdata:///local" + path);
                StorageFile f = await StorageFile.GetFileFromApplicationUriAsync(localUri);
                IRandomAccessStream stream = await f.OpenAsync(FileAccessMode.Read);
                return stream;
            }
            catch (Exception) { throw new Exception("Invalid path"); }
        }
    }
