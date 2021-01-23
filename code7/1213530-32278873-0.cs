    /// <summary>
    /// Custom <see cref="IHttpActionResult"/> that sends files using <see cref="StreamContent"/>
    /// </summary>
    public class FileResult : IHttpActionResult
    {
        ILogger Log = LogManager.GetLogger();
        /// <summary>
        /// Write buffer size. We use it for our internal services so 8MB buffer size - is the size tested and approved to be fine for our 1Gbps LAN transfers ;) you might want to change it
        /// </summary>
        private const int BUFFER_SIZE = 8388608;
        /// <summary>
        /// Initializer
        /// </summary>
        /// <param name="data">File data</param>
        public FileResult(byte[] data)
        {
            Data = data;
        }
        /// <summary>
        /// File data
        /// </summary>
        public byte[] Data
        { get; private set; }
        /// <inheritdoc cref="IHttpActionResult.ExecuteAsync(CancellationToken)"/>
        public async Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage();
            response.Content = new PushStreamContent(async (responseStream, content, context) =>
                {
                    using (var source = new MemoryStream(Data))
                    {
                        try
                        {
                            if (source != null)
                                await source.CopyToAsync(responseStream, BUFFER_SIZE, cancellationToken);
                        }
                        catch (Exception e)
                        {
                            if (cancellationToken.IsCancellationRequested)
                                Log.Info("Data stream read operation aborted by client.");
                            else
                            {
                                Log.Warn(e);
                                throw;
                            }
                        }
                        responseStream.Close();
                    }
                },
                new MediaTypeHeaderValue("application/pdf"));
            response.Content.Headers.ContentLength = Data.Length;
            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = "file.pdf",
                Size = Data.Length,
            };
            return response;
        }
    }
