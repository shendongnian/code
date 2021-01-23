    public async Task<JArray> GetContentAsync(... updateObject)
    {
      HttpResponse  response = await client.PostAsJsonAsync("webapimethod", updateObject);
      if (response.IsSuccessStatusCode)
      {
          return response.Content.ReadAsAsync<JArray>();
      }
    }
