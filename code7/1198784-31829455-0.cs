    String[] values = { "A1", "B1", "C1", "5" };
    var groups = values.GroupBy(s => s.All(char.IsDigit))
                       .ToDictionary(x => x.Key, x => x.ToArray());
    String[] b = groups[false];
    String[] c = groups[true];
