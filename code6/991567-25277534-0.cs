    public class AppSpecificTableNamesHandler : DelegatingHandler
    {
        public const string TablePrefix = "MyType";
        private const string TablesPathPrefix = "/tables/";
        private string tableSuffix;
        public AppSpecificTableNamesHandler(string tableSuffix)
        {
            this.tableSuffix = tableSuffix;
        }
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            UriBuilder uriBuilder = new UriBuilder(request.RequestUri);
            string path = uriBuilder.Path;
            if (path.StartsWith(TablesPathPrefix + TablePrefix))
            {
                path = TablesPathPrefix + TablePrefix +
                    this.tableSuffix + path.Substring(TablesPathPrefix.Length + TablePrefix.Length);
                uriBuilder.Path = path;
                request.RequestUri = uriBuilder.Uri;
            }
            return base.SendAsync(request, cancellationToken);
        }
    }
