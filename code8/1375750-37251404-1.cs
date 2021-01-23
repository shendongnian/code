    if (!File.ReadAllLines(path).Any(x => x.Equals(line)))
    {
        string[] tradeRefLines = File.ReadAllLines(path);
        File.WriteAllLines(path, tradeRefLines); ;
    }
