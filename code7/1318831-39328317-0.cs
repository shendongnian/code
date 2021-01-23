    [Route("CheckId/{id}")]
    [HttpGet]
    public IHttpActionResult CheckId(int id)  
    {
        if (id > 100)
        {
            var message = new HttpResponseMessage(HttpStatusCode.BadRequest)
            {
                Content = new StringContent("We cannot use IDs greater than 100.")
            };
            throw new HttpResponseException(message);
        }
        return Ok(id);
    }
