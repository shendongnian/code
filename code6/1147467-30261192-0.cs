        public class Point
        {
            public string Tag { get; set; }
            public DateTime Time { get; set; }
            public int Value { get; set; }
        }
        public class NewPoint
        {
            public string Tag {get;set;}
            public DateTime Date {get;set;}
            public int LowValue {get;set;}
            public int HighValue {get;set;}
            public double AvgValue {get;set;}
        }
        public List<NewPoint> Summary(List<Point> list)
        {
            return list
                .GroupBy(p => new {p.Tag, p.Time.Date})
                .Select(grp => new NewPoint()
                {
                    Tag = grp.Key.Tag,
                    Date = grp.Key.Date,
                    LowValue = grp.Min(p => p.Value),
                    HighValue = grp.Max(p => p.Value),
                    AvgValue = grp.Average(p => p.Value),                
                })
                .ToList();
        }
