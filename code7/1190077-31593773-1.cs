    public class Download
    {
        public event EventHandler<DownloadStatusChangedEventArgs> DownloadStatusChanged;
        public event EventHandler<DownloadProgressChangedEventArgs> DownloadProgressChanged;
        public event EventHandler DownloadCompleted;
        
        public bool stop = true; // by default stop is true
        // add option get current download speed
        public void DownloadFile(string DownloadLink, string Path)
        {
            stop = false; // always set this bool to false, everytime this method is called
            long ExistingLength = 0;
            FileStream saveFileStream;
            if (File.Exists(Path))
            {
                FileInfo fileInfo = new FileInfo(Path);
                ExistingLength = fileInfo.Length;
                Console.WriteLine(Helper.SizeSuffix(ExistingLength));
            }
            if (ExistingLength > 0)
                saveFileStream = new FileStream(Path, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
            else
                saveFileStream = new FileStream(Path, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
            var request = (HttpWebRequest)HttpWebRequest.Create(DownloadLink);
            request.Proxy = null;
            request.AddRange(ExistingLength);
            try
            {
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    long FileSize = ExistingLength + response.ContentLength; //response.ContentLength gives me the size that is remaining to be downloaded
                    bool downloadResumable; // need it for sending empty progress
                    if ((int)response.StatusCode == 206)
                    {
                        Console.WriteLine("Resumable");
                        var downloadStatusArgs = new DownloadStatusChangedEventArgs();
                        downloadResumable = true;
                        downloadStatusArgs.ResumeSupported = downloadResumable;
                        OnDownloadStatusChanged(downloadStatusArgs);
                    }
                    else // sometimes a server that supports partial content will lose its ability to send partial content(weird behavior) and thus the download will lose its resumability
                    {
                        Console.WriteLine("Resume Not Supported");
                        ExistingLength = 0;
                        var downloadStatusArgs = new DownloadStatusChangedEventArgs();
                        downloadResumable = false;
                        downloadStatusArgs.ResumeSupported = downloadResumable;
                        OnDownloadStatusChanged(downloadStatusArgs);
                        // restart downloading the file from the beginning because it isn't resumable
                        // if this isn't done, the method downloads the file from the beginning and starts writing it after the previously half downloaded file, thus increasing the filesize and corrupting the downloaded file
                        saveFileStream.Dispose(); // dispose object to free it for the next operation
                        File.WriteAllText(Path, string.Empty); // clear the contents of the half downloaded file that can't be resumed
                        saveFileStream = saveFileStream = new FileStream(Path, FileMode.Append, FileAccess.Write, FileShare.ReadWrite); // reopen it for writing
                    }
                    using (var stream = response.GetResponseStream())
                    {
                        byte[] downBuffer = new byte[4096];
                        int byteSize = 0;
                        long totalReceived = byteSize + ExistingLength;
                        //var sw = new Stopwatch();
                        while ((byteSize = stream.Read(downBuffer, 0, downBuffer.Length)) > 0)
                        {
                            //sw.Reset();
                            //sw.Start();
                            saveFileStream.Write(downBuffer, 0, byteSize);
                            totalReceived += byteSize;
                            var args = new DownloadProgressChangedEventArgs();
                            args.BytesReceived = totalReceived;
                            args.TotalBytesToReceive = FileSize;
                            if (downloadResumable == true)
                                args.ProgressPercentage = ((float)totalReceived / (float)FileSize) * 100;
                            else
                                args.ProgressPercentage = 0;
                            Console.WriteLine(0);
                            //args.CurrentSpeed = ;
                            OnDownloadProgressChanged(args);
                            //sw.Stop();
                            if (stop == true) return;
                        }
                    }
                }
                var completedArgs = new EventArgs();
                OnDownloadCompleted(completedArgs);
                saveFileStream.Dispose();
            }
            catch (WebException e)
            {
                string filename = System.IO.Path.GetFileName(Path);
                Console.WriteLine(e.Message);
                saveFileStream.Dispose();
                return; //not needed because this is the last line of the method, but let's keep it here
            }
        }
        public void StopDownload()
        {
            stop = true;
        }
        protected virtual void OnDownloadStatusChanged(DownloadStatusChangedEventArgs e)
        {
            EventHandler<DownloadStatusChangedEventArgs> handler = DownloadStatusChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        protected virtual void OnDownloadProgressChanged(DownloadProgressChangedEventArgs e)
        {
            EventHandler<DownloadProgressChangedEventArgs> handler = DownloadProgressChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        protected virtual void OnDownloadCompleted(EventArgs e)
        {
            EventHandler handler = DownloadCompleted;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
    public class DownloadStatusChangedEventArgs : EventArgs
    {
        public bool ResumeSupported { get; set; }
    }
    public class DownloadProgressChangedEventArgs : EventArgs
    {
        public long BytesReceived { get; set; }
        public long TotalBytesToReceive { get; set; }
        public float ProgressPercentage { get; set; }
        public double CurrentSpeed { get; set; }
    }
