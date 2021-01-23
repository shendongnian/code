    private static void LogTime(IList<TimeSpan> timeList, TimeSpan maxFrameSize, string logFilePath)
    {
        var groupedTimes = timeList
            .OrderBy(i=>i)
            .GroupAdjacentBy((current, next) => next - current <= maxFrameSize)
            .Select(g => new {FromTime = g.First(), ToTime = g.Last()});
    
        var file = new System.IO.FileInfo(logFilePath);
        using (var writer = file.AppendText())
        {
            foreach (var times in groupedTimes)
            {
                writer.WriteLine("{0} - {1}", times.FromTime, times.ToTime);
            }
        }
    }
