    public class RootObject
    {
        public int success { get; set; }
        public Class_d d { get; set; }
    }
    public class Class_d
    {
        public Dictionary<string, GameData> gameData { get; set; }
    }
    public class GameData
    {
        public List<Score> scores { get; set; }
        public int count { get; set; }
        public bool[] highlight { get; set; }
    }
    public class Score
    {
        public decimal max { get; set; }
        public decimal avg { get; set; }
        public int? rest { get; set; }
        public bool active { get; set; }
        public string scoreid { get; set; }
    }
