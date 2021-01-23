      internal class Program
      {
        private static void Main(string[] args)
        {
          Uri[] uris = {new Uri("http://www.google.com"), new Uri("http://www.yahoo.com")};
          Parallel.ForEach(uris, uri =>
          {
            using (var webClient = new MyWebClient())
            {
              try
              {
                var data = webClient.DownloadData(uri);
                // Success, do something with your data
              }
              catch (Exception ex)
              {
                // Something is wrong...
                Console.WriteLine(ex.ToString());
              }
            }
          });
        }
      }
    
      public class MyWebClient : WebClient
      {
        protected override WebRequest GetWebRequest(Uri uri)
        {
          var w = base.GetWebRequest(uri);
          w.Timeout = 5000; // 5 seconds timeout
          return w;
        }
      }
