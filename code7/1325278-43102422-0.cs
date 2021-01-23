        [HttpPost]
        [Route("upload/file")] // you may replace this route to suit your api service
        public async Task<IHttpActionResult> Upload()
        {
            if (!Request.Content.IsMimeMultipartContent("form-data"))
            {
                return BadRequest("Unsupported media type");
            }
            try
            {
                var provider = new MultipartMemoryStreamProvider();
                
                await Request.Content.ReadAsMultipartAsync(provider);
                if (provider.Contents.Count == 0) return InternalServerError(new Exception("Upload failed"));
                var file = provider.Contents[0]; // if you handle more then 1 file you can loop provider.Contents
                var buffer = await file.ReadAsByteArrayAsync();
                // .. do whatever needed here
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.GetBaseException().Message);
            }
        }
