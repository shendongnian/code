    public HttpResponseMessage GetResults(string id, int n) {
        var client = new HttpClient();
        client.DefaultRequestHeaders.Add("Authorization", "Token " + token);
        Stream results = await client.GetStreamAsync(baseurl + id + "/results");
    
        response.Content = new PushStreamContent(
            async (outputStream, httpContent, transportContext) => {
                using(outputStream)
                {
                    StreamReader sr = new StreamReader(results);
                    while(!sr.EndOfStream)
                    {
                        string line = await sr.ReadLineAsync();
                        var decoded = Json.Decode(line);
    
                        //convert to byte array
                        byte[] buffer = //...
    
                        await outputStream.WriteAsync(buffer, 0, buffer.Length);
                    }
                }
        });
    }
