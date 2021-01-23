    public class TravelTypeA : ITravel {}
    public class TravelTypeB : ITravel {}
    [HttpPost]
    public object PostMeATravel(ITravel travel)
    {
        // check what type is travel with "is" or ".GetType()"
    }
