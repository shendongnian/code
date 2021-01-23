    // Assuming a 2D table and not jagged
    List<List<string>> table = new List<List<string>>
    {
        new List<string> { "1", "2", "3" },              
        new List<string> { "1", "2", "3" },
        new List<string> { "1", "2", "3" },
        new List<string> { "2", "3", "4" }
    };
    List<decimal> footerTotals = new List<decimal>();
    for (int i = 0; i < table[0].Count; i++)
    {
        // Sum the columns
        footerTotals.Add(table.Sum(t => decimal.Parse(t[i])));
    }
    table.ForEach(row => Console.WriteLine(String.Join("\t", row)));
    Console.WriteLine(String.Join("\t", footerTotals));
