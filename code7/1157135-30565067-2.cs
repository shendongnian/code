    Dictionary<Resource, Dictionary<double, int>> rewards = new Dictionary<Resource, Dictionary<double, int>>();
    public class Mission
    {
        public Resource ResourceToAward { get; set; }
        public double Time { get; set; }
    }
    public enum Resource
    {
        ResourceOne,
        ResourceTwo,
        ResourceThree,
        ResourceFour
    }
