    public class Title
    {
        public string text { get; set; }
        public int x { get; set; }
    }
    public class Subtitle
    {
        public string text { get; set; }
        public int x { get; set; }
    }
    public class XAxis
    {
        public List<string> categories { get; set; }
    }
    public class PlotLine
    {
        public int value { get; set; }
        public int width { get; set; }
        public string color { get; set; }
    }
    public class YAxis
    {
        public Title title { get; set; }
        public List<PlotLine> plotLines { get; set; }
    }
    public class Tooltip
    {
        public string valueSuffix { get; set; }
    }
    public class Legend
    {
        public string layout { get; set; }
        public string align { get; set; }
        public string verticalAlign { get; set; }
        public int borderWidth { get; set; }
    }
    public class Series
    {
        public string name { get; set; }
        public List<double?> data { get; set; }
    }
    public class HighChartsData
    {
        public Title title { get; set; }
        public Subtitle subtitle { get; set; }
        public XAxis xAxis { get; set; }
        public YAxis yAxis { get; set; }
        public Tooltip tooltip { get; set; }
        public Legend legend { get; set; }
        public List<Series> series { get; set; }
    }
