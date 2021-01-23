        [HttpGet]
        [Route("attachments/{id:guid}/download")]
        public IHttpActionResult DownloadAttachment(Guid id) {
            var attachment = this.repository.FindById(id);
            if (attachment == null) {
                return this.NotFound();
            }
            return new DocumentAttachmentResult(attachment.Name, attachment.FileType.MimeType, attachment.BinaryBlob);
        }
