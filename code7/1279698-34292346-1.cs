    public static async Task<string> createRequest(string url, int timeout = 1)
    {
         using(var client = new HttpClient())
         {
              client.Timeout = TimeSpan.FromSeconds(timeout);
              string response = await client.GetStringAsync(url);
              // Handle response here
              return handledResponse; // You can return a raw string
         }
    }
