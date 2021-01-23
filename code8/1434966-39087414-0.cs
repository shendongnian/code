        class DateSpan
        {
            public DateTime StartDate;
            public DateTime EndDate;
            public DateSpan(DateTime start, DateTime end)
            {
                StartDate = start;
                EndDate = end;
            }
            public DateSpan(DateTime start, int duration)
            {
                StartDate = start;
                EndDate = start.AddHours(duration);
            }
        }
        public void TestStuff()
        {
            var dates1 = new System.Collections.Generic.List<DateSpan>();
            dates1.Add(new DateSpan(new DateTime(2016, 1, 1, 5, 0, 0), 17));
            dates1.Add(new DateSpan(new DateTime(2016, 1, 2, 4, 0, 0), 4));
            var dates2 = new System.Collections.Generic.List<DateSpan>();
            dates2.Add(new DateSpan(new DateTime(2016, 1, 1, 10, 0, 0), 1));
            dates2.Add(new DateSpan(new DateTime(2016, 1, 1, 16, 0, 0), 1 ));
            dates2.Add(new DateSpan(new DateTime(2016, 1, 2, 5,0,0), 17 ));
            var e = dates1.SelectMany((DateSpan x) =>
            {
                var result = new List<DateSpan>();
                foreach (var o in dates2.Where(y => x.StartDate < y.StartDate && y.StartDate < x.EndDate).ToList())
                {
                    result.Add(new DateSpan(new DateTime(Math.Max(x.StartDate.Ticks, o.StartDate.Ticks)), new DateTime(Math.Min(x.EndDate.Ticks, o.EndDate.Ticks))));
                }
                return result;
            });
            //var d = dates1.Where(x => dates2.Any(y => x.StartDate < y.StartDate && y.StartDate < x.EndDate)).ToList();
        }
