    public MainPage()
    {
        this.InitializeComponent();
        this.LoadContents();
    }
    private async void LoadContents()
    {
        HttpClient httpClient = new HttpClient();
        String responseLine;
        JObject o;
        try
        {
            string responseBodyAsText;
            HttpResponseMessage response = await httpClient.GetAsync("http://localhost/list.php");
            //response = await client.PostAsync(url, new FormUrlEncodedContent(values));
            response.EnsureSuccessStatusCode();
            responseBodyAsText = await response.Content.ReadAsStringAsync();
           // responseLine = responseBodyAsText;
              string Website = "http://localhost/list.php";
            Task<string> datatask =  httpClient.GetStringAsync(new Uri(string.Format(Website, DateTime.UtcNow.Ticks)));
            string data = await datatask;
            o = JObject.Parse(data);
            Debug.WriteLine("firstname:" + o["id"][0]);
        }
        catch (HttpRequestException hre)
        {
            // You might want to actually handle the exception
            // instead of silently swallowing it.
        }
    }
