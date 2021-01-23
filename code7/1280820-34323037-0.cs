    public class Xarcies
    {
        public int id { get; set; }
        public string name { get; set; }
        public int profileIconId { get; set; }
        public long revisionDate { get; set; }
        public int summonerLevel { get; set; }
    }
    public class RootObject
    {
        public Xarcies xarcies { get; set; }
    }
