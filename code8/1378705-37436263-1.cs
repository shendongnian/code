    public class MethodToTest
    {
        public delegate string RollDelegate(int number);
        public RollDelegate MethodDelegate { get; set; }
        public List<long> timeSpent { get; set; }
        public MethodToTest()
        {
            timeSpent = new List<long>();
        }
        public string TimeStats()
        {
            return string.Format("Min: {0}ms, Max: {1}ms, Avg: {2}ms", timeSpent.Min(), timeSpent.Max(),
                timeSpent.Average());
        }
    }
