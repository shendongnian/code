    public static List<DateRange> MakeRanges(List<DateTime?> list1, List<DateTime?> list2)
    {
        if (list1 == null || list2 == null || list1.Count == 0 ||
            list2.Count == 0 || list1.Count != list2.Count)
        {
            throw new ArgumentException("Bad arguments passed to MakeRanges().");
        }
        //If present, replace null start value of list1 with a sentinel
        list1[0] = list1[0] ?? DateTime.MinValue;
        //If present, replace null end value of list2 with a sentinel 
        list2[list2.Count - 1] = list2[list2.Count - 1] ?? DateTime.MaxValue;
        return list1.Where(s => s.HasValue).Select( startItem => new DateRange{
                Start = startItem,
                End = list2.Find(e => (e.HasValue && (e > startItem.Value))).Value
            }).ToList();
    }
