    public static List<DateRange> GetContiguousTimespans(List<DateRange> ranges)
    {
        List<DateRange> result = new List<DateRange>();
        ranges.Sort((a,b)=>a.Start.CompareTo(b.Start));
        DateRange cur = ranges[0];
        for (int i = 1; i < ranges.Count; i++)
        {
            if (ranges[i].Start <= cur.End)
            {
                if (ranges[i].End >= cur.End)
                    cur.End = ranges[i].End;
            }
            else
            {
                result.Add(cur);
                cur = ranges[i];
            }
        }
        result.Add(cur);
        return result;
    }
