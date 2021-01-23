    public async Task<List<T>> GetCustomerAsync()
    {
        var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        var json = await httpClient.GetStringAsync(WebServiceUrl);
        var taskModels = JsonConvert.DeserializeObject<List<T>>(json);
        return taskModels;
      }
