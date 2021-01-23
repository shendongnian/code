    protected List<TimeRange> GetBoundedTimeRanges(List<TimeRange> timeRanges, DateTime startTime, DateTime endTime)
    {
        var startSearch = timeRanges.BinarySearch(new TimeRange(startTime, startTime), new TimeRangeComparer());
        if (startSearch < 0)
        {
            startSearch = ~startSearch;
        }
        var ranges = new List<TimeRange>();
        for (int i = startSearch; i < timeRanges.Count; i++)
        {
            var range = timeRanges[i];
            if (range.End < startTime)
            {
                continue;
            }
            if (range.Start > endTime)
            {
                break;
            }
            ranges.Add(range);
        }
        return ranges;
    }
    class TimeRangeComparer : IComparer<TimeRange>
    {
        public int Compare(TimeRange x, TimeRange y)
        {
            var startResult = x.End.CompareTo(y.Start);
            if (startResult != 0)
            {
                return startResult;
            }
            return x.End.CompareTo(y.End);
        }
    }
