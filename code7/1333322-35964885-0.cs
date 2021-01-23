    var players = JsonConvert.DeserializeObject<Dictionary<string, Player>>(json);
    public class Entry
    {
        public string playerOrTeamId { get; set; }
        public string playerOrTeamName { get; set; }
        public string division { get; set; }
        public int leaguePoints { get; set; }
        public int wins { get; set; }
        public int losses { get; set; }
        public bool isHotStreak { get; set; }
        public bool isVeteran { get; set; }
        public bool isFreshBlood { get; set; }
        public bool isInactive { get; set; }
    }
    public class Player
    {
        public string name { get; set; }
        public string tier { get; set; }
        public string queue { get; set; }
        public List<Entry> entries { get; set; }
    }
