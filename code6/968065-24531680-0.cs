    using System.Windows.Forms.DataVisualization.Charting;
    ...
    public class MyChart: Chart
    {
        public void MyChartMethod() { }
    }
    public class MySeries : Series
    {
        public MySeries(String name) : base(name)
        {
        }
        public void MySeriesMethod() { }
    }
