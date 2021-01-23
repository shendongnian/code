    public async void LiveStream()
    {
        using(var client = new HttpClient())
        {
            client.Timeout = new TimeSpan(SET DESIRED TIMEOUT);
            string response = client.GetStringAsync("http://api.sample.com");
        }
    }
