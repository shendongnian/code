        public class BarChart : IChart
        {
            public BarData BarChartData { get; private set; }
            public BarStyle BarChartStyle { get; private set; }
            // Other custom members you desire for your bad chart implementation
            public BarChart(BarData data, BarStyle style)
            {
                BarChartData = data;
                BarChartStyle = style;
            }
        }
