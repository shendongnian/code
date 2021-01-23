    private void TestParallelForeach()
    {
      string[] uris = {"http://192.168.1.2", "http://192.168.1.3", "http://192.168.1.4"};
      var results = new List<string>();
      var syncObj = new object();
      Parallel.ForEach(uris, uri =>
      {
        using (var webClient = new WebClient())
        {
          webClient.Encoding = Encoding.UTF8;
          try
          {
            var result = webClient.DownloadString(uri);
            lock (syncObj)
            {
              results.Add(result);
            }
          }
          catch (Exception ex)
          {
            // Do error handling here...
          }
        }
      });
      // Do with "results" here....
    }
