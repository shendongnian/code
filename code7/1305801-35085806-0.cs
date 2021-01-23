    [HttpGet, Route("groups/{type}/{id?}")]
    public IHttpActionResult GetParticipantGroupForScheduleEvent(string type, Guid? id = null)
    {
        var request = new ScheduleEventParticipantGroupRequest
        {
            Type = type,
            Id = id
        };
        //assuming this returns an object or list of objects
        var response = GettingParticipantGroupForScheduleEventService.HandleGroupRequest(request);
        return Ok(response);
    }
