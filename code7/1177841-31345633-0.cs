    public IHttpActionResult Get(int id)
    {
        if(id == 10)
        {
            return StatusCode(HttpStatusCode.NotFound);
        }
    
        return Ok("Some value");
    }
