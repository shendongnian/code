    public static List<DateRange> GetContiguousTimespans(List<DateRange> ranges)
    {
        //convert my DateRange objects into the objects used by the Time Period Library
        TimePeriodCollection periods = new TimePeriodCollection();
        ranges.ForEach(ts => periods.Add(new TimeRange(ts.Start, ts.End)));
        //get a list of contiguous date ranges
        TimePeriodCombiner<TimeRange> periodCombiner = new TimePeriodCombiner<TimeRange>();
        ITimePeriodCollection combinedPeriods = periodCombiner.CombinePeriods(periods);
        //convert the objects back to DateRanges
        List<DateRange> result = combinedPeriods.Select(cp => new DateRange(cp.Start, cp.End)).ToList();
        return result;
    }
