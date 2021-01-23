    public class ChartSeriesData
    {
        public string[] XValues { set; get; }
        public string[] YValues { set; get; }
        public string Name { set; get; }
    }
    public class MyChartData
    {
        public List<ChartSeriesData> Series { set; get; }
        public string Name { set; get; }
    }
