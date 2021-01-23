    [HttpPost]
    public async Task<IActionResult> Post([FromBody]MyPostDataClass MyPostData)
    {
       var dummyTrace = new TraceTelemetry("hello", SeverityLevel.Verbose);
       mTelemetryClient.TrackTrace(dummyTrace);
       string opId = dummyTrace.Context.Operation.Id;
       
       return Ok();
    }
