    public async ReturnType MethodName()
    {
         string resourceAddress = "url";
         string postBody = "jsonbody";
         var httpClient = new HttpClient();
         httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
         HttpResponseMessage x = await httpClient.PostAsync(resourceAddress, new StringContent(postBody, Encoding.UTF8, "application/json"));
    }
