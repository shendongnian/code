    [HttpGet]
    public IQueryable GetTimes()
    {
        var times = context.Events.where(x => x.EventName == "even name")
                           .Select(x => x new Event
                                    {
                                      Id = x.Id,
                                      EventName = x.EventName,
                                      StartTime = x.StartTime, 
                                      FinishTime = x.FinishTime
                                    });  
    }
