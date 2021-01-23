    [HttpGet]
    [ODataRoute("Orders({id})/Your.Namespace.GetByExternalKey(key={key})")]
    public IHttpActionResult GetByExternalKey(long key)
    {
       return Ok(from o in db.Orders
          where//SpecialCrazyStuff is done
          select o);
    }
