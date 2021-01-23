    //api/person/byId?id=1
    [HttpGet("byId")] 
    public string Get(int id)
    {
    }
    //api/person/byName?firstName=a&lastName=b
    [HttpGet("byName")]
    public string Get(string firstName, string lastName, string address)
    {
    }
