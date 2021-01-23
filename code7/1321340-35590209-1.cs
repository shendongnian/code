    public async Task<IHttpActionResult> GetSomething()
    {
        var rawMessage = await Request.Content.ReadAsStringAsync();
        // ...
        return Ok();
    }
