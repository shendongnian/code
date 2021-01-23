    [EnableQuery]
    public IHttpActionResult GetFrom([RouteData]Type type)
    {
    	var ofType = typeof(Queryable).GetMethod("OfType").MakeGenericMethod(type);
   		return Ok((IQueryable<Base>)ofType.Invoke(null, new object[] { this.Context.Bases }));
    }
