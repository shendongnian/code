    [HttpGet]
    public async Task<IHttpActionResult> Get(string country)
    {
        var result = repo.GetCategories(new List<string> { country });
        return Ok(result);
    }
