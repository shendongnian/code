    public class Player
    {
        public int account_id { get; set; }
        public string name { get; set; }
        public int hero_id { get; set; }
        public int team { get; set; }
    }
    
    public class Container
    {
        public List<Player> players { get; set; }
    }
