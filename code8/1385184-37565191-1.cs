    Progress<DownloadOperation> progressCallback = new Progress<DownloadOperation>(DownloadProgress);
    await download.AttachAsync().AsTask(cancelToken.Token, progressCallback);
    
    
    private void DownloadProgress(DownloadOperation download)
        {
            try
            {
                MyClass myClass = myClasses.First(p => p.DownloadOperation == download);
                myClass.Progress = (int)((download.Progress.BytesReceived * 100) / download.Progress.TotalBytesToReceive);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
        }
