    public IHttpActionResult GetInteger() {
       // Ok is a convenience method for returning a 200 Ok response
       return Ok(new {
          value = 1
       });
    }
