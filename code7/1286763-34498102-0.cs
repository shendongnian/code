    [HttpGet, Route("api/sampledates/startdate/{startDate}/enddate/{endDate}/offset/{offset}/type{type}")]
    public IActionResult Get(DateTime startDate, DateTime endDate, int offset = 0, string type = "defaultType")
    {
        List<DateTime> sampleDates = new List<DateTime>()
        {
            new DateTime(2015, 1, 22),
            new DateTime(2015, 2, 22),
            new DateTime(2015, 3, 22),
            new DateTime(2015, 4, 22),
        };
    
        return Ok(sampleDates);
    }
