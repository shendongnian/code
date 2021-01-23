    public async Task LoadDataAsync(string uri)
    {
        if (allRecords != null) **// Breakpoint here never hit.**
        {
            string responseJsonString = null;
            using (var httpClient = new HttpClient())
            {
                try
                {
                    Task<HttpResponseMessage> getResponse = httpClient.GetAsync(uri);
                    HttpResponseMessage response = await getResponse;
                    responseJsonString = await response.Content.ReadAsStringAsync();
                    myList = JsonConvert.DeserializeObject<List<MyListItem>>(responseJsonString);
                }
                catch (Exception ex)
                {
                }
            }
        }
    }
