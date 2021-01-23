        public static IEnumerable<Tuple<short, short>> ExcludeIntervals(IEnumerable<ISchedule> range)
        {
            var list = range
                .SelectMany(x => new[] {Tuple.Create(x.TimeFrom, x.IsOn), Tuple.Create(x.TimeTo, !x.IsOn)})
                .OrderBy(d => d.Item1).ThenBy(d => d.Item2)
                .ToList();
            var first = default(short);
            var count = 1;
            foreach (var item in list)
            {
                if (item.Item2) // false - start of unavailability interval. true - end of unavailability interval.
                {
                    if (--count == 0) // Become available.
                    {
                        first = item.Item1;
                    }
                }
                else
                {
                    if (++count == 1)
                    {
                        var last = item.Item1;
                        if (last >= first) // if next unavailability starts right after previous ended, then no gap.
                        {
                            yield return Tuple.Create(first, last);
                        }
                    }
                }
            }
        }
        public interface ISchedule
        {
            bool IsOn { get; set; }
            short TimeFrom { get; set; }
            short TimeTo { get; set; }
        }
