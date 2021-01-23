    public async Task<IHttpActionResult> FooAsync()
    {
          var json = await Request.Content.ReadAsStringAsync();
          var content = JsonConvert.DeserializeObject<VMRegistrant>(json);
    }
