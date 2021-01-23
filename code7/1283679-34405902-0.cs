    public class WC : WebClient
    {
        protected override WebRequest GetWebRequest(Uri url)
        {
            var request = base.GetWebRequest(url) as HttpWebRequest;
            request.AutomaticDecompression = DecompressionMethods.GZip;
            
            return request;
        }
    }
