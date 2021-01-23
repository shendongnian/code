    [Route("/api/items/{id}")]
    public IHttpActionResult Get(int id, int? page = null, int? perpage = null)
    {
       // some relevant code
       return Ok();
    }
