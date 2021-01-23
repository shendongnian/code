    public class DocumentAttachmentResult : IHttpActionResult {
        private readonly string fileName;
        private readonly string mimeType;
        private readonly byte[] blob;
        public DocumentAttachmentResult(string fileName, string mimeType, byte[] blob) {
            this.fileName = fileName;
            this.mimeType = mimeType;
            this.blob = blob;
        }
        private HttpResponseMessage Execute() {
            var response = new HttpResponseMessage(HttpStatusCode.OK) { Content = new StreamContent(new MemoryStream(this.blob)) };
            response.Content.Headers.Add("Content-Type", this.mimeType);
            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") { FileName = this.fileName };
            return response;
        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken) {
            return Task.FromResult(this.Execute());
        }
    }
