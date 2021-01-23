            var times = new List<string>
            {
                "06:56",
                "06:58",
                "06:55",
                "06:54",
                "06:54",
                "06:53",
                "06:55",
                "06:53",
                "06:58",
                "06:54",
                "06:58",
                "06:55",
                "06:54",
                "06:50",
                "06:54",
                "06:57"
            };
            var average = times
                .Select(TimeSpan.Parse)
                .Average(x => x.TotalMilliseconds);
            var averageTime = TimeSpan.FromMilliseconds(average);
