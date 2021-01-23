    [HttpGet]
    [Route("{id:int}"]
    public ExternalUser Get(int id)
    { }
    [HttpGet]
    [Route(""]
    public ExternalUser Get(Guid guid)
    { }
    [HttpGet]
    [Route("")]
    public IEnumerable<ExternalUser> Get()
    { }
    [HttpGet]
    [Route("")]
    public ExternalUser Get(string username)
    { }
