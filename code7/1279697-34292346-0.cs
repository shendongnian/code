    public static async Task<string> createRequest(string url, int timeout = 1)
    {
         using(var client = new HttpClient())
         {
              client.Timeout = TimeSpan.FromSeconds(timeout);
              return await client.GetStringAsync(url);
         }
    }
