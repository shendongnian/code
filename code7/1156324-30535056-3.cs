    using (WebClient wc = new WebClient())
    {
        wc.DownloadFileCompleted += ((sender, args) =>
        {
            if (args.Error == null)
            {
                File.Move(filePath, Path.ChangeExtension(filePath, ".jpg"));
                mr.Set();
            }
            else
            {
                //how to pass args.Error?
            }
        });
        Task.Factory.StartNew(() => wc.DownloadFile(
                                     new Uri(string.Format("{0}/{1}",
                                     Settings1.Default.WebPhotosLocation,
                                     Path.GetFileName(f.FullName))), filePath))
                    .ContinueWith(t => Console.WriteLine(t.Exception.Message));
    }
