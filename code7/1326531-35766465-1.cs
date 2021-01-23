    [HttpPost]
    [Route("events/add")]
    public void AddEvent(myTemporaryEventModel postedData)
    {
        TimeInteval interval = new TimeInterval(){
            StartDateUtc = postedData.Start,
            EndDateUtc = postedData.End
        }
        CustomEvent event = new CustomEvent(){
            Id = postedData.Id,
            Name = postedData.Name,
            DateRange = interval
        }        
    } 
