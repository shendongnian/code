       [HttpPost]
        public HttpResponseMessage ZipDocs([FromBody] string[] docs)
        {
            using (ZipFile zip = new ZipFile())
            {
                //this code takes an array of documents' paths and Zip them
                zip.AddFiles(docs, false, "");
                return ZipContentResult(zip);
            }
        }
        protected HttpResponseMessage ZipContentResult(ZipFile zipFile)
        {
            var pushStreamContent = new PushStreamContent((stream, content, context) =>
            {
              zipFile.Save(stream);
                stream.Close(); 
            }, "application/zip");
            return new HttpResponseMessage(HttpStatusCode.OK) { Content = pushStreamContent };
        }
