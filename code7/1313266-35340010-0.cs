    internal class ProgressableStreamContent : HttpContent
    {
        private const int defaultBufferSize = 4096;
        private Stream content;
        private int bufferSize;
        private bool contentConsumed;
        private Download downloader;
        public ProgressableStreamContent(Stream content, Download downloader) : this(content, defaultBufferSize, downloader) {}
        public ProgressableStreamContent(Stream content, int bufferSize, Download downloader)
        {
            if(content == null)
            {
                throw new ArgumentNullException("content");
            }
            if(bufferSize <= 0)
            {
                throw new ArgumentOutOfRangeException("bufferSize");
            }
            this.content = content;
            this.bufferSize = bufferSize;
            this.downloader = downloader;
        }
            
        protected override Task SerializeToStreamAsync(Stream stream, TransportContext context)
        {
            Contract.Assert(stream != null);
            PrepareContent();
            return Task.Run(() =>
            {
                var buffer = new Byte[this.bufferSize];
                var size = content.Length;
                var uploaded = 0;
                downloader.ChangeState(DownloadState.PendingUpload);
                using(content) while(true)
                {
                    var length = content.Read(buffer, 0, buffer.Length);
                    if(length <= 0) break;
                    downloader.Uploaded = uploaded += length;
                    stream.Write(buffer, 0, length);
                    downloader.ChangeState(DownloadState.Uploading);
                }
                downloader.ChangeState(DownloadState.PendingResponse);
            });
        }
        protected override bool TryComputeLength(out long length)
        {
            length = content.Length;
            return true;
        }
        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                content.Dispose();
            }
            base.Dispose(disposing);
        }
        private void PrepareContent()
        {
            if(contentConsumed)
            {
                // If the content needs to be written to a target stream a 2nd time, then the stream must support
                // seeking (e.g. a FileStream), otherwise the stream can't be copied a second time to a target 
                // stream (e.g. a NetworkStream).
                if(content.CanSeek)
                {
                    content.Position = 0;
                }
                else
                {
                    throw new InvalidOperationException("SR.net_http_content_stream_already_read");
                }
            }
            contentConsumed = true;
        }
    }
