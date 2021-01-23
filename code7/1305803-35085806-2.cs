    [HttpGet, Route("api/scheduleevents/groups/{type}/{id:guid?}")]
    public IHttpActionResult GetParticipantGroupForScheduleEvent(string type, Guid? id = null)
    {
        try
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
        catch
        {
           return InternalServerError();
        }
    }
