    [HttpPost, Route("api/products/add")]
    public IHttpActionResult ReturnListProd([FromBody]JOTA PP)
    {
        try
        {
            //do something with passed in data
            var name = PP.Name;
            //always at minimum return a status code
            return Ok();
        }
        catch
        {
            //returns 500
            return InternalServerError();
        }
    }
