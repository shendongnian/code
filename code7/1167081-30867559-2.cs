    public async Task<IHttpActionResult> Get()
    {
      IEnumerable<Thing> things = await DoLongDbCallAsync();
      return Ok(things);
    }
