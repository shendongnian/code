    public async void LiveStream()
    {
        using(var client = new HttpClient())
        {
            client.Timeout = new TimeSpan(SET DESIRED TIMEOUT);
            var response = client.GetAsync("http://api.sample.com");
            if(repsone.IsSuccessStatusCode)
            {
                string contentJson = response.Content.ReadAsStringAsync();
            }
        }
    }
