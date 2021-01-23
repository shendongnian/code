      public class WebClientExtended : WebClient
      {
        protected override WebRequest GetWebRequest(Uri uri)
        {
          var w = (HttpWebRequest) base.GetWebRequest(uri);
          w.Timeout = 5000;      // Set timeout
          w.KeepAlive = true;    // Set keepalive true or false
          w.ServicePoint.SetTcpKeepAlive(true, 1000, 5000);  // Set tcp keepalive
          return w;
        }
      }
