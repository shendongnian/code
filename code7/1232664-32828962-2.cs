    public Task<T> GetData<T>()
    {
      WebRequest request = WebRequest.Create("http://addresstojson.com/json.json");
      using (WebResponse response = await request.GetResponseAsync())
      {
        using(var stream = new StreamReader(response.GetResponseStream()))
        {
            string json = await stream.ReadToEndAsync();
            T result = JsonConvert.DeserializeObject<T>();
            return result;
        }
      }
    }
