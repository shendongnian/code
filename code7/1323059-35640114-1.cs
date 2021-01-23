    public async Task<string> TestOcrAsync(string filePath)
    {
        // Read the file bytes
        var fileBytes = File.ReadAllBytes(filePath);
        var fileName = Path.GetFileName(filePath);
        // Set up the multipart request
        var requestContent = new MultipartFormDataContent();
        // Add the demo API key ("helloworld")
        requestContent.Add(new StringContent("helloworld"), "apikey");
        // Add the file content
        var imageContent = new ByteArrayContent(fileBytes);
        imageContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
        requestContent.Add(imageContent, "file", fileName); 
        // POST to the API
        var client = new HttpClient();
        var response = await client.PostAsync("https://api.ocr.space/parse/image", requestContent);
        return await response.Content.ReadAsStringAsync();
    }
