    public class AddThreatViewModel
    {
       public string Description { get; set; }
       //since it's a add view model, we dont need a ThreatId here
    }
    [HttpPost]
    public ActionResult AddThreat(AddThreatViewModel model)
    {
        //convert the view model to Threat, add to database
    }
  
    public class AddThreatEvent
    {
        public int ThreatId { get; set; }
        public int SecrutiyEventId { get; set; }
    }
    [HttpPost]
    public ActionResult AddThreatEvent(AddThreatEventmodel)
    {
        //add threat event into existing threat
    }
