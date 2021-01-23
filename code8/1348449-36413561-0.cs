    static public async Task<JToken> GetInfoAsync()
    {
      var httpClientRequest = new HttpClient ();
      try {
        ...
      } catch {
        //no connection
        return new JValue(false);
      }
    }
