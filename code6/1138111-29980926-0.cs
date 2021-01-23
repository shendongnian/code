    public async Task<byte[]> PostFileRequest(string url, string filename, MemoryStream file)
    {
        var client = new HttpClient();
        var content = new MultipartFormDataContent();
        var streamContent = new StreamContent(file);
        streamContent.Headers.Add("Content-Type", "application/octet-stream");
        streamContent.Headers.Add("Content-Disposition", "form-data; name=\"file\"; filename=\"" + filename + "\"");
        content.Add(streamContent, "file", filename);
        content.Headers.Add("X-ZUMO-APPLICATION", Constants.MobileServiceApplicationKey);
        var response = await client.PostAsync(Constants.MobileServiceUrl + "api/" + url, content);
        if (response.StatusCode == HttpStatusCode.OK)
        {
            byte[] responseContent = await response.Content.ReadAsByteArrayAsync();
            return responseContent;
        }
        return null;
    }
