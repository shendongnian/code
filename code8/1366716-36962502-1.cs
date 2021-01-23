    [Route("/ducks/{BodyOfWaterType}")]
    public class NotifyDucksSwimming 
    {
        public int HowManyDucks { get; set; }
        public int BodyOfWaterType { get; set; }
    }
