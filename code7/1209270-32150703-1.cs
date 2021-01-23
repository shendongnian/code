    public class MyDlClass
    {
        public async Task DownloadProtocol(IProgress<double> progress, string address, string location)
        {
            Uri Uri = new Uri(address);
            using (WebClient client = new WebClient())
            {
                //client.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                //client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgress);
                client.DownloadProgressChanged += (o, e) =>
                {
                    Console.WriteLine(e.BytesReceived + " " + e.ProgressPercentage);
                    progress.Report(e.ProgressPercentage);
                };
                client.DownloadFileCompleted += (o, e) =>
                {
                    if (e.Cancelled == true)
                    {
                        Console.WriteLine("Download has been canceled.");
                    }
                    else
                    {
                        Console.WriteLine("Download completed!");
                    }
                };
                await client.DownloadFileTaskAsync(Uri, location);
            }
        }
    }
