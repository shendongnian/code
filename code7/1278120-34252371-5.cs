    public class DecompressedHttpContent: HttpContent
    {
        private readonly HttpContent _content;
        public DecompressedHttpContent(HttpContent content)
        {
            _content = content;
            foreach (var header in _content.Headers)
            {
                Headers.TryAddWithoutValidation(header.Key, header.Value);
            }
        }
        protected override async Task SerializeToStreamAsync(Stream stream, TransportContext context)
        {
            using (var originalStream = await _content.ReadAsStreamAsync())
            using (var gzipStream = new GZipStream(originalStream, CompressionMode.Decompress))
            {
                await gzipStream.CopyToAsync(stream);
            }
        }
        protected override bool TryComputeLength(out long length)
        {
            length = -1;
            return false;
        }
    }
