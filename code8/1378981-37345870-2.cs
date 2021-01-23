    [HttpGet]
    public IQueryable<EventDTO> GetTimes()
    {
        return context.Events.where(x => x.EventName == "even name")
                           .Select(x => x new EventDTO
                                    {
                                      Id = x.Id,
                                      EventName = x.EventName,
                                      StartTime = x.StartTime.TimeOfDay, 
                                      FinishTime = x.FinishTime.TimeOfDay
                                    });  
    }
