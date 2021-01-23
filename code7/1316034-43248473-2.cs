        [ActionName("FileUpload")]
        [HttpPost]
        public ActionResult FileUpload_Post()
        {
            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];
                
                using (HttpClient client = new HttpClient())
                {
                    using (var content = new MultipartFormDataContent())
                    {
                        byte[] fileBytes = new byte[file.InputStream.Length + 1];                         
                        file.InputStream.Read(fileBytes, 0, fileBytes.Length);
                        var fileContent = new ByteArrayContent(fileBytes);
                        fileContent.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment") { FileName = file.FileName };
                        content.Add(fileContent);
                        var result = client.PostAsync(requestUri, content).Result;
                        if (result.StatusCode == System.Net.HttpStatusCode.Created)
                        {
                            ViewBag.Message= "Created";
                        }
                        else
                        {
                            ViewBag.Message= "Failed";
                        }
                    }
                }
            }
            return View();
        }
