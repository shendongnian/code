    int filesDownloaded = 0;
    foreach (var fileName in ListOfFileNames)
    {
        Task.Factory.StartNew((path) =>
        {
            DownloadMyFile(path);
            Log.WriteLine(string.Format("Downloaded File: {0}",path), Log.Status.Success); 
            lock (thislock)
            {
                filesDownloaded++;
            }
        }, fileName);
    }
