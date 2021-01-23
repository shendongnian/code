    public class CustomResolver : XmlUrlResolver
    {
        public override object GetEntity(Uri absoluteUri, string role, Type ofObjectToReturn)
        {
            // base calls XmlUrlResolver.DownloadManager.GetStream(...) here
        }
    }
