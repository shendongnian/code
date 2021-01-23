    [HttpGet]
    [Route("ReportDetailed/{clientId:int}/{date:datetime}")]
    public IHttpActionResult ReportDetailed(int clientId, DateTime date )
    {
        return Ok();
    }
