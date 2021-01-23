    public async Task OnlineSolve(string image)
    {
      await GetSession(apikey).ConfigureAwait(false);
    }
    private async Task GetSession(string apikey)
    {
          ...misc code
      using (var httpClient = new HttpClient())
      {
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        HttpContent contentPost = new StringContent(input, Encoding.UTF8, "application/x-www-form-urlencoded");
        using (var response = await httpClient.PostAsync(baseAddress, contentPost).ConfigureAwait(false))
        {
          string responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
          ...more stuff
        }
      }
    }
