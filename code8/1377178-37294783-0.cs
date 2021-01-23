    FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
---------
     public async Task<FileResult> ImagePath(string filePath)
        {
          
            HttpClientHandler handler = new HttpClientHandler()
            {
                UseDefaultCredentials = true,
            };
            using (var client = new HttpClient(handler)) {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("image/jpeg"));
                HttpResponseMessage fs = await client.GetAsync("cipap/api/baseapi/ImagePath?filePath=" + filePath);
                return File(fs.Content.ReadAsByteArrayAsync().Result, "image/jpeg");               
            }
          
        }
