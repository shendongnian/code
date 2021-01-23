    using (var fileContent = new FileStream(@"C:\temp\testfile.txt", FileMode.Open))
    using (var client = new HttpClient())
    {
        var content = new StreamContent(fileContent);
        content.Headers.ContentType = new MediaTypeHeaderValue("text/plain");
        client.BaseAddress = new Uri("http://localhost:81");
        HttpResponseMessage response =
            await client.PutAsync(@"/api/storage/testfile.txt", content);
    }
