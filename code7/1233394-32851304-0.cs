            Dictionary<string, string[]> SortedTestingData = new Dictionary<string, string[]>();
            SortedTestingData.Add("1", new string[] { "a", "b", "c" });
            SortedTestingData.Add("2", new string[] { "d", "b", "e" });
            SortedTestingData.Add("3", new string[] { "d", "b", "f" });
            SortedTestingData.Add("4", new string[] { "a", "b", "c" });
            var runningNumbers = from vals in SortedTestingData
                                 from val in vals.Value
                                 group val by val into g
                                 select new
                                 {
                                     Value = g.Key,
                                     Count = g.Count()
                                 };
