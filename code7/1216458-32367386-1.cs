    CancellationTokenSource cts; // write this on top of your class
    
    public void CancelDownloadingFile()
    {
          if (cts != null)
        {
            cts.Cancel();
        }
    }
