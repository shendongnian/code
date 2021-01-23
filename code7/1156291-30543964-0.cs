    HttpClient httpClient = new HttpClient();
    MultipartFormDataContent content = new MultipartFormDataContent();
    content.Add(new StringContent(parameter), "name");
    content.Add(new StreamContent(stream), "param", "filename");
            
    HttpResponseMessage httpResponseMessage = await httpClient.PostAsync(address, content);
