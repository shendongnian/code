    public class CheckedFileStreamResult : FileStreamResult
    {
        public CheckedFileStreamResult(FileStream stream, string contentType)
            :base(stream, contentType)
        {
            DownloadCompleted = false;
        }
        public bool DownloadCompleted { get; set; }
        protected override void WriteFile(HttpResponseBase response)
        {
            var outputStream = response.OutputStream;
            using (FileStream)
            {
                var buffer = new byte[_bufferSize];
                var count = FileStream.Read(buffer, 0, _bufferSize);
                while(count != 0 && response.IsClientConnected)
                {                 
                    outputStream.Write(buffer, 0, count);
                    count = FileStream.Read(buffer, 0, _bufferSize);
                }
                DownloadCompleted = response.IsClientConnected;
            }
        }
    
        private const int _bufferSize = 0x1000;
    }
