      internal class Program
      {
        private static int _downloadCounter;
        private static readonly object _syncObj = new object();
    
        private static void Main(string[] args)
        {
          Uri[] uris = {new Uri("http://www.google.com"), new Uri("http://www.yahoo.com")};
          foreach (var uri in uris)
          {
            var webClient = new WebClient();
            webClient.DownloadDataCompleted += OnWebClientDownloadDataCompleted;
            webClient.DownloadDataAsync(uri);
          }
          Thread.Sleep(Timeout.Infinite);
        }
    
        private static void OnWebClientDownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
        {
          if (e.Error == null)
          {
            // OK
            Console.WriteLine(Encoding.UTF8.GetString(e.Result));
          }
          else
          {
            // Error
            Console.WriteLine(e.Error.ToString());
          }
    
          lock (_syncObj)
          {
            _downloadCounter++;
            Console.WriteLine("Counter = {0}", _downloadCounter);
          }
    
          var webClient = sender as WebClient;
          if (webClient == null) return;
          webClient.DownloadDataCompleted -= OnWebClientDownloadDataCompleted;
          webClient.Dispose();
        }
      }
