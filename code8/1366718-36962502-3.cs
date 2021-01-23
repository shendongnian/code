    [Route("/ducks/{BodyOfWaterType}")]
    public class NotifyDucksSwimming 
    {
        public int HowManyDucks { get; set; }
        public string BodyOfWaterType { get; set; }
    }
