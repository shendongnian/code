    var result = lst.GroupBy(g => g.StatusID).OrderBy(g => g.Key).Select(g => columns.Select(c =>
        {
            if (c == "StatusID") return g.Key;
            var val = g.FirstOrDefault(r => r.MonthYear == c);
            return val != null ? val.Count : 0;
        }).ToList()).ToList();
