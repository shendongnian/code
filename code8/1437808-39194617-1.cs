    [Authorize(Roles = "Developer")]
    // GET: api/Tests
    public IEnumerable<string> Get()
    {
        return new string[] { "value1", "value2" };
    }
