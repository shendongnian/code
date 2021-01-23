    public class UriNode
    {
        public Uri ThisUri { get; private set; }
        public IEnumerable<UriNode> Children { get; private set; }
        public UriNode(CloudBlobContainer container, Uri thisUri = null)
        {
            ThisUri = thisUri;
            if (ThisUri == null)
            {
                Children = container.ListBlobs().Select(b => new UriNode(container, b.Uri));
                return;
            }
            if (!new Regex(@"\/$").IsMatch(ThisUri.AbsolutePath)) return;
            var prefix = string.Join("/", ThisUri.Segments.Skip(2).Take(ThisUri.Segments.Length - 2));
            Children = container.ListBlobs(prefix).Select(b => new UriNode(container, b.Uri));
        }
    }
