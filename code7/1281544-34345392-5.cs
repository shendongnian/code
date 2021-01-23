    private static Dictionary<string, decimal> ReadSalvageValuesFromFile(string fileName)
    {
        string[] lines = File.ReadAllLines(fileName);
        var dict = new Dictionary<string, decimal>()
        foreach (string line in lines) {
            string[] parts = line.Split(',');
            decimal value;
            if (parts.Lengh >= 2 && Decimal.TryParse(parts[1].Trim(), out value)) {
                dict.Add(parts[0].Trim(), value);
            }
        }
        return dict;
    }
