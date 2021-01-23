    static async Task<JObect> Upload(string key, string url, string 
                                 sourceFile, string targetFormat)
    { 
        using (HttpClientHandler handler = new HttpClientHandler { 
                                               Credentials = new NetworkCredential(key, "") 
                                       })
        using (HttpClient client = new HttpClient(handler))
        {
             var request = new MultipartFormDataContent();
             request.Add(new StringContent(targetFormat), "target_format");
             request.Add(new StreamContent(File.OpenRead(sourceFile)),
                                       "source_file",
                                        new FileInfo(sourceFile).Name);
            using (HttpResponseMessage response = await client.PostAsync(url,request))
            using (HttpContent content = response.Content)
            {
                string data = await content.ReadAsStringAsync();
                return JsonObject.Parse(data);
            }
        }
    }
