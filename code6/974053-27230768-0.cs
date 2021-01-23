    class DataForCombinedChart
    {
        List<ChartData> AllChartData { get; set; }
    }
    
    class ChartData
    {
        String SeriesName { get; set; }
        DateTime SampleTime { get; set; }
        int SampleReading { get; set; }
    }
