    public class ChartItem
    {
        public double Value { get; set; }
        public DateTime Time { get; set; }
        public ChartItem(DateTime time, double value)
        {
            Value = value;
            Time = time;
        }
    }
