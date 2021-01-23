    [HttpGet]
    public string Get() { ... }
    [ChildActionOnly]
    public SendResponse Send(..) { ... }
    [ChildActionOnly]
    public SendResponse SendImage(..) { ... }
    [HttpPost]
    public SendResponse Post([FromBody]xxx yyy) { ... }
    [HttpPut]
    public void Put(..) { ... }
    [HttpDelete]
    public void Delete(..) { ... }
