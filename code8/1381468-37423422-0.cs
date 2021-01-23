    const string ServerUrl = ""; //specify your server url
        
     public void ClientHeaderInfo(HttpClient client)
     {
            client.BaseAddress = new Uri(ServerUrl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
     }
     
    public virtual async Task Post(int id,string url)
        {
            HttpClientHandler handler = new HttpClientHandler { UseDefaultCredentials = true };
            using (var client = new HttpClient(handler))
            {
                ClientHeaderInfo(client);
                try
                {
                    await client.PostAsJsonAsync(url, id);
                }
                catch (Exception ex)
                {
                    await new MessageDialog(ex.Message).ShowAsync();
                }
            }
        }
