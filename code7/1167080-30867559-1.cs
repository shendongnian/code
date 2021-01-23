    public async Task<IHttpActionResult> Get()
    {
      IEnumerable<Thing> things = await Task.Run(() => DoLongDbCall());
      return Ok(things);
    }
