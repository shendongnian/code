    //Request DTO
    
    [Route("/there/are/{HowManyDucks}/swimming/in/the/{BodyOfWaterType}")]
    public class NotifyDucksSwimming 
    {
        public int HowManyDucks { get; set; }
        public string BodyOfWaterType { get; set; }
    }
    
    //Implementation
    
    public object Any(NotifyDucksSwimming request)
    {
        //...
    }
