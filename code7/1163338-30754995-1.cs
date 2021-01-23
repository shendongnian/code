    internal class Range
    {
        internal DateTime From, To;
        public Range(string aFrom, string aTo)
        {
            From = DateTime.ParseExact(aFrom, "dd/mm/yy", CultureInfo.InvariantCulture);
            To = DateTime.ParseExact(aTo, "dd/mm/yy", CultureInfo.InvariantCulture);
        }
    }
        public static int ComputeNights(IEnumerable<Range> ranges)
        {
            var vSet = new HashSet<DateTime>();
            foreach (var range in ranges)
                for (var i = range.From; i < range.To; i = i.AddDays(1)) vSet.Add(i)
            return vSet.Count;
        }
