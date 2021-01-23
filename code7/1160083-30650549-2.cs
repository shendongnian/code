    IEnumerable<string[]> query = from row in data
                                  where row[0] == "1000200034"
                                  group row by new { FirstKey = row[0], SecondKey = row[1] } into g
                                  select new string[]
            {
                g.Key.FirstKey,
                g.Key.SecondKey,
                g.Sum(a=>int.Parse(a.ElementAt(3))).ToString(),   
            };
