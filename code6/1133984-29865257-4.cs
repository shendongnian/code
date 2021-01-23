    var webClient = new WebClient()
    webClient.OpenReadCompleted += OnUploadCompleted;
    webClient.OpenReadAsync(url, data);
    private void OnUploadCompleted(object sender, OpenReadCompletedEventArgs e)
    {
        if (e.Error != null)
        {
             // Error, do something useful
             return;
        }
        using (var responseStream = e.Result)
        {
               byte[] data = (byte[]) e.UserState;
              // Read response from stream.
        }
    }
