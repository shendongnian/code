    class FileUploader
    {
        private readonly Uri _destination;
        public FileUploader(Uri destination)
        {
            _destination = destination;
        }
        public void UploadFiles(IEnumerable<string> fileNames)
        {
            foreach (var fileName in fileNames)
            {
                UploadFile(fileName);
            }
        }
        private void UploadFile(string fileName)
        {
            var tcs = new TaskCompletionSource<bool>();
            using (var client = new WebClient())
            {
                client.UploadProgressChanged += UploadProgressChangedHandler;
                client.UploadFileCompleted += (sender, args) => UploadCompletedHandler(fileName, tcs, args);
                client.UploadFileAsync(_destination, fileName);
                tcs.Task.Wait();
            }
        }
        private void UploadCompletedHandler(string fileName, TaskCompletionSource<bool> tcs, UploadFileCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                tcs.TrySetCanceled();
            }
            else if (e.Error != null)
            {
                tcs.TrySetException(e.Error);
            }
            else
            {
                tcs.TrySetResult(true);
            }
        }
        private void UploadProgressChangedHandler(object sender, UploadProgressChangedEventArgs e)
        {
            // Handle progress, e.g.
            System.Diagnostics.Debug.WriteLine(e.ProgressPercentage);
        }
    }
