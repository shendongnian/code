    [HttpPost]
        [ActionName("ZipFileAction")]
        public HttpResponseMessage ZipFiles([FromBody]int[] id)
        {
            if (id == null)
            {//Required IDs were not provided
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.BadRequest));
            }
            List<Document> documents = new List<Document>();
            using (var context = new ApplicationDbContext())
            {
                foreach (int NextDocument in id)
                {
                    Document document = context.Documents.Find(NextDocument);
                    if (document == null)
                    {
                        throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
                    }
                    documents.Add(document);
                }
                var streamContent = new PushStreamContent((outputStream, httpContext, transportContent) =>
                {
                    try
                    {
                        using (var zipFile = new ZipFile())
                        {
                            foreach (var d in documents)
                            {
                                var dt = d.DocumentDate.ToString("y").Replace('/', '-').Replace(':', '-');
                                string fileName = String.Format("{0}-{1}-{2}.pdf", dt, d.PipeName, d.LocationAb);
                                FileInfo fi = new FileInfo(d.DocumentUrl);
                                var fileReadStream = fi.OpenRead();
                                var fileSize = (int)fi.Length;
                                var fileContent = new byte[fileSize];
                                fileReadStream.Read(fileContent, 0, fileSize);
                                zipFile.AddEntry(fileName, fileContent);
                            }
                            zipFile.Save(outputStream); //Null Reference Exception
                        }
                    }
                    
                    finally
                    {
                        outputStream.Close();
                    }
                });
                streamContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                streamContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
                streamContent.Headers.ContentDisposition.FileName = "reports.zip";
                var response = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = streamContent
                };
                return response;
            }
        }
    }
