    public async Task SendAsync(string filePath)
    {
        string url = "http://localhost/api/method";
    
        MultipartFormDataContent content = new MultipartFormDataContent();
    
        var fileContent = new StreamContent(File.OpenRead(filePath));
        fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
        fileContent.Headers.ContentDisposition.FileName = "file.txt";
        fileContent.Headers.ContentDisposition.Name = "file";
        fileContent.Headers.ContentType = new MediaTypeHeaderValue("text/xml");
        content.Add(fileContent);
    
        using (HttpClient client = new HttpClient())
        {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    
            HttpResponseMessage response = await client.PostAsync(url, content);
        }
    }
