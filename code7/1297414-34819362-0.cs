    [HttpPost]
    public string MakeUser([FromBody]UserParameters p)
    {
        ...
    }
    var client = new HttpClient();
    client.DefaultRequestHeaders.Accept.Clear();
    var response = await client.PostAsJsonAsync(new Uri("http://localhost:4688/"), p);
    // do something with response
