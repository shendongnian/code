    public interface ITravel
    {
      public int TravelId { get; set; }
    }
    public class TravelTypeA : ITravel
    {
      public int TravelId { get; set; }
      public string Destination { get; set; }
    }
    public class TravelTypeB : ITravel
    {
      ...
    }
    [HttpPost]
    public object PostMeATravel(ITravel travel)
    {
        // check what type is travel with "is" or ".GetType()"
    }
