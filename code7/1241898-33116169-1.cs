    IEnumerable<string> lines = File.ReadLines(@"C:\Program Files (x86)\makeeuro\work.txt");
    Dictionary<string, int> values = lines
        .Where(l => !string.IsNullOrEmpty(l))
        .Select(s => s.Split(':'))
        .ToDictionary(split => split[0], split => int.Parse(split[1]));
