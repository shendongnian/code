    using (HttpClient httpClient = new HttpClient())
    {
      httpClient.BaseAddress = new Uri(baseAPIURL);
      httpClient.DefaultRequestHeaders.Accept.Clear();
      httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
      var response = await httpClient.GetAsync(uri);
      if (response.IsSuccessStatusCode)
      {
        return await response.Content.ReadAsAsync<T>();
      }
    }
    return default(T);
