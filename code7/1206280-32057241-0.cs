            var dates = new List<Tuple<DateTime, DateTime>>
                            {
                                new Tuple<DateTime, DateTime>(new DateTime(2001, 1, 1), new DateTime(2005, 1, 12)), 
                                new Tuple<DateTime, DateTime>(new DateTime(2006, 1, 1), new DateTime(2006, 4, 4)), 
                                new Tuple<DateTime, DateTime>(new DateTime(2007, 1, 5), new DateTime(2007, 10, 15)), 
                                new Tuple<DateTime, DateTime>(new DateTime(2009, 1, 2), new DateTime(2009, 4, 5)), 
                                new Tuple<DateTime, DateTime>(new DateTime(2007, 3, 3), new DateTime(2009, 5, 3))
                            };
            var overlaps = (from t1 in dates
                            from t2 in dates
                            where !Equals(t1, t2) // Don’t match the same object.
                            where t1.Item1 <= t2.Item2 && t1.Item2 >= t2.Item1   //check intersections
                            select t2).Distinct();
