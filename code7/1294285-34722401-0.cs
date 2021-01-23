    [HttpGet]
    public string DayOfWeek() {
       return DateTime.Now.ToString("dddd");
    }
    
    [HttpGet]
    public int DayNumber() {
       return DateTime.Now.Day;
    }
