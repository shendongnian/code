    public class Stats
    {
        public int Money { get; set; }
        public int Income { get; set; }
        public override string ToString()
        {
            return Money + " " + Income;
        }
    }
