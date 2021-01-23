    [Route("getall")]
    public IHttpActionResult GetAllItems()
    {
        var result = new
        {
            x = "hello",
            y = "world"
        };
        return Ok(JsonConvert.SerializeObject(result));
    }
