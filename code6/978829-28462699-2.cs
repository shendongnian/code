     using (var httpClient = new HttpClient())
    {
        var uri = new Uri("http://example.com/api/controller"));
        
        using (var formData = new MultipartFormDataContent())
        {
            //add content to form data
            formData.Add(new StringContent(JsonConvert.SerializeObject(content)), "Content");
            //add config to form data
            formData.Add(new StringContent(JsonConvert.SerializeObject(config)), "Config");
                                
            var response = httpClient.PostAsync(uri, formData);
            response.Wait();
            if (!response.Result.IsSuccessStatusCode)
            {
                //error handling code goes here
            }
        }
    }
