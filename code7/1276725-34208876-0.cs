    public class Player
    {
        public Player()
        {
            this.weapons = new SortedDictionary<string, Weapon>(new PrefixedNumericStringComparer("weapon_"));
        }
        public string steamid { get; set; }
        public string name { get; set; }
        public string team { get; set; }
        public string activity { get; set; }
        public State state { get; set; }
        public SortedDictionary<string, Weapon> weapons { get; set; }
        public MatchStats match_stats { get; set; }
    }
