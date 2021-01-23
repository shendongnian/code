    foreach (FileInfo file in files)
    {
        loadedMessage = OpenPop.Mime.Message.Load(file);
        allLoadedMessages.Add(loadedMessage);
        counter += 1; //put before the progress;
        int nProgress = counter * 100 / files.Length;
        backgroundWorker2.ReportProgress(nProgress);
    }
