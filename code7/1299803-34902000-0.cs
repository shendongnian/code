    private int totalUploadCounter = 0;
    private int counter = 0;
    public void UploadFile()
    { 
      string[] dirs = Directory.GetFiles(path + dataDir); 
      totalUploadCounter = 0;
      counter = 0;
      foreach (var dir in dirs) {
        totalUploadCounter += Directory.GetFiles(dir).Length;
      }
    
      // your upload code here
     }
    
    void WebClientUploadCompleted(object sender, UploadFileCompletedEventArgs e)
    {
        counter++;
        if (counter == totalUploadCounter) {
          // ALL UPLOADS FINISHED!!!
        }
    }
