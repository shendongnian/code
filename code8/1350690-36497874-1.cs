    [HttpGet]
    [Route("v1/samples/{id}", Name="SampleGet")]
    [ResponseType(typeof(string))]
    public async Task<IHttpActionResult> Get(int id)
    {
        return Ok("value");
    }
