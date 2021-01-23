    // Call this method to start the download
    private void DownloadData()
    {
        // Create a TaskFactory on the current Thread; the UI thread
        TaskFactory UITaskFactory = 
            new TaskFactory(TaskScheduler.FromCurrentSynchronizationContext());
    
        // Create and start a Task that will download the data
        var DoDownloadTake = Task.Factory.StartNew(() =>
        {
            Boolean success = false;
            try
            {
                WebClient wc = new WebClient();
                byte[] pbo = wc.DownloadData(PathOnWebserver);
                FileStream dwn = File.Create(LocalPath);
                dwn.Write(pbo, 0, pbo.Length);
                dwn.Close();
                success = true;
            }
            catch(Exception ex){} // Handles this however you'd like to.
    
            // Call a method on the UI thread to notify us the download completed
            UITaskFactory.StartNew(() => DataFinishedDownloading(success));
        });
    }
    
    // Once the data is finished downloading this method will be called
    private void DataFinishedDownloading(Boolean success)
    {
        if(success)
            ;// Do something with data at LocalPath
        else
            ;// Download failed
    }
