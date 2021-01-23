    using (var client = new HttpClient())
    {
        client.BaseAddress = new Uri(ConfigurationManager.AppSettings["MyServer"]);
    
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    
        HttpResponseMessage response = await client.GetAsync("api/VerifyMyModel/PostAsync");
        if (response.IsSuccessStatusCode)
        {
            var myResponseModel = await response.Content.ReadAsAsync<MyResponseModel>();
        }
    }
