    public static Tuple<DateTime, DateTime?> MinStartMaxEnd(this IQueryable<Section> source)
    {
      if(source == null)
        return null;
      var minMax = (from s0 in source
      from s1 in source
      orderby s0.StartDate, s1.EndDate descending
      select new {s0.StartDate, s1.EndDate}).FirstOrDefault();
      return minMax == null ? null : Tuple.Create(minMax.StartDate, minMax.EndDate);
    }
    public static Tuple<DateTime, DateTime?> MinStartMaxEnd(this IEnumerable<Section> source)
    {
      if(source != null)
        using(var en = source.GetEnumerator())
          if(en.MoveNext())
          {
            var cur = en.Current;
            var start = cur.StartDate;
            var end = cur.EndDate;
            while(en.MoveNext())
            {
              cur = en.Current;
              if(cur.StartDate < start)
                start = cur.StartDate;
              if(cur.EndDate.HasValue && (!end.HasValue || cur.EndDate > end))
                end = cur.EndDate;
            }
            return Tuple.Create(start, end);
          }
      return null;
    }
