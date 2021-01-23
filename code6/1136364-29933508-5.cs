    private async Task UploadFile(HttpClient client, Stream fileStream, string filename)
    {
        //HttpClient initialized by caller
        using (var content = new MultipartFormDataContent())
        {
            //file contains XML
            content.Add(CreateFileContent(fileStream, filename, "text/xml"));
            var resp = await client.PostAsync("the/rest/endpoint", content);
            resp.EnsureSuccessStatusCode();
        }
        return;
        // Error handling left as an exercise for the reader.
    }
