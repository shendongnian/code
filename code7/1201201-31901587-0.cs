     [JsonDictionary]
    public class JsonClass : Dictionary<string, List<PlayerClass>>
    {
    }
    public class PlayerClass
    {
        public string name { get; set; }
        public string tier { get; set; }
        public string queue { get; set; }
        public List<PlayerDetails> entries { get; set; }
    }
    public class PlayerDetails
    {
        public string playerOrTeamId { get; set; }
        public string playerOrTeamName { get; set; }
        public string division { get; set; }
        public long leaguePoints { get; set; }
        public long wins { get; set; }
        public long losses { get; set; }
        public bool isHotStreak { get; set; }
        public bool isVeteran { get; set; }
        public bool isFreshBlood { get; set; }
        public bool isInactive { get; set; }
    }
