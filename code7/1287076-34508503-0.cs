    protected T PostAsync<T, TR>(string serviceUrl, TR request)
    {
        using (var client = new HttpClient())
        {
            var baseUrl = "";
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    
            var response = client.PostAsJsonAsync(serviceUrl, request).Result;
    
            if (response.IsSuccessStatusCode)
            {
                var responseString = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<T>(responseString);
            }
        }
    
        return default(T);
    }
