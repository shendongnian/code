    public class Lineup
    {
        public List<Player> Players { get; set; }
    }
    public class Player
    {
        public string id { get; set; }
        public string game_id { get; set; }
        public string player_id { get; set; }
        public string jersey_number { get; set; }
    }
    public class Result
    {
        public List<Lineup> Lineups { get; set; }
    }
