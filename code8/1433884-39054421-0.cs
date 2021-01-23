    private async void onButtonClick(object sender, EventArgs e)
    {
        await GetValuesAsync();
    }
    private async Task GetValuesAsync()
    {   
        string ResponseJsonString = null;
        string url =
            "http://myWebapp.azurewebsites.net/api/values";
        using (var httpClient = new HttpClient())
        {
            try
            {
                Task<HttpResponseMessage> getResponse = httpClient.GetAsync(url);
                HttpResponseMessage response = await getResponse; //Execution hangs here forever ...
                ResponseJsonString = await response.Content.ReadAsStringAsync();
                values = JsonConvert.DeserializeObject<string[]>(ResponseJsonString);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
