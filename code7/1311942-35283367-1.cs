    public IEnumerable<Stats> CalculateStats(List<Data> bufferData, DateTime startTime, TimeSpan windowWidth)
    {
        var finishTime = bufferData.Last().Time;
        return bufferData
            .Select(x => new
            { 
                x.Value,
                WindowIndex = GetWindowIndex(x.Time, startTime, windowWidth)
            })
            .GroupBy(
                x => x.WindowIndex,
                (i, items) => new Stats
                { 
                    StartTime = GetWindowTime(startTime, windowWidth, i),
                    FinishTime = GetWindowTime(startTime, windowWidth, i + 1),
                    Mean = (float)items.Average(x => x.Value),
                    Max = (float)items.Max(x => x.Value),
                    Min = (float)items.Min(x => x.Value)
                });
    }
    
    private int GetWindowIndex(DateTime time, DateTime startTime, TimeSpan windowWidth)
    {
        var timeSinceStart = time - startTime;
        var secondsSinceStart = timeSinceStart.TotalSeconds;
        return (int)Math.Ceiling(secondsSinceStart / windowWidth.TotalSeconds);
    }
    
    private DateTime GetWindowTime(DateTime startTime, TimeSpan windowWidth, int windowIndex)
    {
        return startTime + TimeSpan.FromSeconds(windowWidth.TotalSeconds * windowIndex);
    }
    
    public class Stats
    {
        public DateTime StartTime { get; set; }
        public DateTime FinishTime { get; set; }
        public float Mean { get; set; }
        public float Max { get; set; }
        public float Min { get; set; }
    }
    
    public class Data
    {
        public float Value { get; set; }
        public DateTime Time { get; set; }
    }
