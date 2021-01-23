    // Asynchronous download method that gets a String
    public async Task<string> DownloadString(Uri uri) {
       var task = new TaskCompletionSource<string>();
    
       try {
          var client = new WebClient();
          client.DownloadStringCompleted += (s, e) => {
             task.SetResult(e.Result);
       };
    
       client.DownloadStringAsync(uri);
       } catch (Exception ex) {
          task.SetException(ex);
       }
    
       return await task.Task;
    }
    private void TestMethod() {
       // Start a new download task asynchronously
       var task = DownloadString(new Uri("http://mywebsite.com"));
       // Wait for the result
       task.Wait();
       // Read the result
       String resultString = task.Result;
    }
