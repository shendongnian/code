    public class PickItem
    {
        public string Pick { get; set; }
        public double Odds { get; set; }
    }
    public class BetOffer
    {
        public string BetType { get; set; }
        public List<PickItem> Picks { get; set; }
    }
    public class BetPick
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<BetOffer> BetOffers { get; set; }
    }
    public class MyRootObject
    {
        public List<List<BetPick>> @event { get; set; }
    }
---
    var root = new JavaScriptSerializer().Deserialize<MyRootObject>(jsonString);
