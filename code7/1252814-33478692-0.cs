    private static async Task<string> checkAvaibleAsync(string url)
    {
      using (var client = new HttpClient())
      {
        string htmlCode = await client.GetStringAsync(url); 
        if (htmlCode.IndexOf("Brak takiego obiektu w naszej bazie!") == -1)
          return url;
        else
          return null;
      }
    }
