    using (var reset = new ManualResetEventSlim(false))
    using (WebClient wc = new WebClient())
    {
        wc.DownloadFileCompleted += (sender, args) => 
        {
            reset.Set();
        };
        wc.DownloadProgressChanged += (sender, args) =>
        {
            progress = (float) args.BytesReceived / (float) args.TotalBytesToReceive;
        };
        wc.DownloadFileAsync(new Uri(noLastSegment + file), path);
        reset.Wait();
    }
