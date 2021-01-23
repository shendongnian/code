    class Range
    {
        internal DateTime From, To;
    }
        public static int ComputeNights(IEnumerable<Range> ranges)
        {
            var vSet = new HashSet<DateTime>();
            DateTime from = DateTime.MinValue;
            DateTime to = DateTime.MaxValue;
            foreach (var range in ranges)
            {
                for (var i = range.From; i < range.To; i = i.AddDays(1))
                    if (vSet.Add(i))
                    {
                        if (i > from) from = i;
                        if (i < to) to = i;
                    }
            }
            return (int)(to - from).TotalDays;
        }
