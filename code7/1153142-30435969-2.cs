    [HttpGet]
    [Route("api/meetings")]
    public ... GetMeetings([FromUri] DateTime startDate, [FromUri] DateTime endDate)
    [HttpGet]
    [Route("api/meetings")]
    public ... GetMeetings([FromUri] DateTime date)
