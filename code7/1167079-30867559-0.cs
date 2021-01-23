    public IHttpActionResult Get()
    {
      IEnumerable<Thing> things = DoLongDbCall();
      return Ok(things);
    }
