    [HttpGet]
    [Route("Calls/{id:int?}/{callId:int?}")]
    public async Task<IHttpActionResult> GetCall([FromUri]int? id = null, [FromUri]int? callId = null)
    {
        var test = string.Format("id: {0} callid: {1}", id, callId);
        return Ok(test);
    }
