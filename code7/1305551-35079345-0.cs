    public string PrepareAndStartv2(
        string orderNumber,
        string userName,
        string systemName)
    {
        string uri =
            string.Format(PrepareAndStartUri, orderNumber, userName, systemName);
        string batchName = null;
        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri(webApiHost);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    
            HttpContent content = new StringContent(string.Empty, Encoding.UTF8, "application/json");
            HttpResponseMessage message = client.PutAsync(uri, content).Result;
            batchName = message.Content.ReadAsStringAsync().Result;
        }
        return batchName;
    }
