    using (var httpClient = new HttpClient())
    {
        httpClient.BaseAddress = new Uri(myWebSite);
        httpClient.DefaultRequestHeaders.Accept.Clear();
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/xml"));
        StringContent stringContent = new StringContent(myXMLData);
        stringContent.Headers.ContentType = new MediaTypeHeaderValue("text/xml");
        HttpResponseMessage httpResponseMessage = httpClient.PostAsync(httpClient.BaseAddress, stringContent).Result;
        string result = httpResponseMessage.Content.ReadAsStringAsync().Result;
    }
