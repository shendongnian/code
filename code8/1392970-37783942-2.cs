    [Serializable]
    public class Stats
    {
        public int rank;
        public string score;
        public string name;
    }
    
    [Serializable]
    public class WeeklyStatsItem
    {
        public string check;
        public List<Stats> stats;
    }
