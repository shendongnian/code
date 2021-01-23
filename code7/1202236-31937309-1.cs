    [HttpGet]
    public Task<IHttpActionResult> Get(string country)
    {
        var result = repo.GetCategories(new List<string> { country });
        return Task.FromResult(Ok(result));
    }
