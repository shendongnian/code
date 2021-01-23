    public class CompressHandler : DelegatingHandler
    {
        private static CompressHandler _handler;
        private CompressHandler(){}
        public static CompressHandler GetSingleton()
        {
            if (_handler == null)
                _handler = new CompressHandler();
            return _handler;
        }
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return base.SendAsync(request, cancellationToken).ContinueWith<HttpResponseMessage>((responseToCompleteTask) =>
            {
                HttpResponseMessage response = responseToCompleteTask.Result;
                var acceptedEncoding =GetAcceptedEncoding(response);
                if(acceptedEncoding!=null)
                    response.Content = new CompressedContent(response.Content, acceptedEncoding);
                return response;
            },
            TaskContinuationOptions.OnlyOnRanToCompletion);
        }
        private string GetAcceptedEncoding(HttpResponseMessage response)
        {
            string encodingType=null;
            if (response.RequestMessage.Headers.AcceptEncoding != null && response.RequestMessage.Headers.AcceptEncoding.Any())
            {
                encodingType = response.RequestMessage.Headers.AcceptEncoding.First().Value;
            }
            return encodingType;
        }
    }
        public class CompressedContent : HttpContent
    {
        private HttpContent originalContent;
        private string encodingType;
        public CompressedContent(HttpContent content, string encodingType)
        {
            if (content == null)
            {
                throw new ArgumentNullException("content");
            }
            if (encodingType == null)
            {
                throw new ArgumentNullException("encodingType");
            }
            originalContent = content;
            this.encodingType = encodingType.ToLowerInvariant();
            if (this.encodingType != "gzip" && this.encodingType != "deflate")
            {
                throw new InvalidOperationException(string.Format("Encoding '{0}' is not supported. Only supports gzip or deflate encoding.", this.encodingType));
            }
            // copy the headers from the original content
            foreach (KeyValuePair<string, IEnumerable<string>> header in originalContent.Headers)
            {
                this.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }
            this.Headers.ContentEncoding.Add(encodingType);
        }
        protected override bool TryComputeLength(out long length)
        {
            length = -1;
            return false;
        }
        protected override Task SerializeToStreamAsync(Stream stream, TransportContext context)
        {
            Stream compressedStream = null;
            if (encodingType == "gzip")
            {
                compressedStream = new GZipStream(stream, CompressionMode.Compress, leaveOpen: true);
            }
            else if (encodingType == "deflate")
            {
                compressedStream = new DeflateStream(stream, CompressionMode.Compress, leaveOpen: true);
            }
            return originalContent.CopyToAsync(compressedStream).ContinueWith(tsk =>
            {
                if (compressedStream != null)
                {
                    compressedStream.Dispose();
                }
            });
        }
    }
