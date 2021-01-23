    public void GetData<T>()
    {
        WebRequest request = WebRequest.Create("http://addresstojson.com/json.json");
        WebResponse response = await request.GetResponseAsync();
    
        using(var stream = new StreamReader(response.GetResponseStream()))
        {
            json = JsonConvert.DeserializeObject<T>(stream.ReadToEnd());
        }
    }
