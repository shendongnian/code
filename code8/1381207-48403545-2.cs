    [HttpPost]
        [Route("api/modeltemplate")]
        public async Task<IHttpActionResult> Post()
        {
            if (!Request.Content.IsMimeMultipartContent())
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            var provider = new MultipartMemoryStreamProvider();
            await Request.Content.ReadAsMultipartAsync(provider);
            var file = provider.Contents.First(x => x.Headers.ContentDisposition.Name == "\"file\"");
            var filename = "";
            var buffer = new byte[0];
            if (file.Headers.ContentDisposition.FileName != null)
            {
                filename = file.Headers.ContentDisposition.FileName.Trim('\"');
                buffer = await file.ReadAsByteArrayAsync();
            }
            var formContent = provider.Contents.First(x => x.Headers.ContentDisposition.Name == "\"modelTemplate\"");
            Task<string> stringContentsTask = formContent.ReadAsStringAsync();
            var stringContents = stringContentsTask.Result;
            var dto = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(stringContents);
            var result = ApiHelper.Add<dynamic>("modeltemplate", dto);
            return Ok(result);
        }
