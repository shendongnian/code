    private void TestMethodCallback() {
    
       // Start a new download task asynchronously
       DownloadString(new Uri("http://mywebsite.com"), (resultString) => {
          // This code inside will be run after asynchronous downloading
          MessageBox.Show(resultString);
       });
    
       // The code will continue to run here
    }
    
    // Downlaod example with Callback-method
    public async void DownloadString(Uri uri, Action<String> callback) {
    
       var client = new WebClient();
       client.DownloadStringCompleted += (s, e) => {
          callback(e.Result);
       };
    
       client.DownloadStringAsync(uri);
    }
