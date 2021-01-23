    public async static Task<byte[]> FromYouTubeAsync(string videoUri)
    {
      using (var client = new HttpClient())
      {
        return await FromYouTubeAsync(...);
      }
    }
