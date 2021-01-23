    public class WebClientEx : WebClient
    {
        protected override WebRequest GetWebRequest(Uri address)
        {
          var webRequest = (HttpWebRequest) base.GetWebRequest(address);
          if (webRequest != null)
          {
            webRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
          }
          return webRequest;
        }
    }
