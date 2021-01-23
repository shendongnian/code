    static async Task PutAccount()
    {
        using (HttpClient client = new HttpClient())
        {
            client.BaseAddress = new Uri("http://yourWebSite.com");
            var acc = new Account() { AccountID = 1234, AccountName = "zzzzP" };
            string json = JsonConvert.SerializeObject(acc);                
            using (HttpResponseMessage response = await client.PutAsync("api/Account/Save", new StringContent(json)))
            {
                return response.EnsureSuccessStatusCode();
            }
        }
    }
