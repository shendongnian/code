    String[] values = { "A1", "B1", "C1", "5", "string" };
    var groups = values.ToLookup(s => s.All(char.IsDigit) ? 1 : s.All(char.IsLetter) ? -1 : 0);
    String[] alldigit = groups[1].ToArray();
    String[] allLetter= groups[-1].ToArray();
    String[] mixed    = groups[0].ToArray();
