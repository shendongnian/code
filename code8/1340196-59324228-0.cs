    public class LocalWebClient : WebClient
    {
        protected override WebRequest GetWebRequest(Uri uri)
        {
            WebRequest w = base.GetWebRequest(uri);
            w.Timeout = 10 * 60 * 1000;//10 minutes
            return w;
        }
    }
