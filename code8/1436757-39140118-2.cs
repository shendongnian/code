    var eventDtos = new List<EventDto>();
    
    if (includeAddress)
       eventDtos.AddRange(this.IncludeAddress(dbContext));
    else
       eventDtos.AddRange(this.NoAddress(dbContext));
    
    eventDtos.ForEach(e => { if (e.Address == null) e.Address = new Address(); });
