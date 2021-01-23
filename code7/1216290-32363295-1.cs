    var words = Regex.Matches(File.ReadAllText(filename), @"\w+").Cast<Match>()
                .Select((m, pos) => new { Word = m.Value, Pos = pos })
                .GroupBy(s => s.Word, StringComparer.CurrentCultureIgnoreCase)
                .Select(g => new { Word = g.Key, PosInText = g.Select(z => z.Pos).ToList() })
                .ToList();
    foreach(var item in words)
    {
        Console.WriteLine("{0,-15} POS:{1}", item.Word, string.Join(",", item.PosInText));
    }
