    private static string GetNextId(string seed)
    {
        var letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string nextId = string.Empty;
        if (seed == "ZZ999")
            throw new ArgumentOutOfRangeException("I can handle till ZZ999 only!");
        var intPart = int.Parse(seed.Substring(2, 3));
        if (intPart < 999)
            nextId = seed.Substring(0, 2) + (++intPart).ToString("000");
        else
        {
            var char2idx = letters.IndexOf(seed.Substring(1, 1));
            if (char2idx < letters.Length)
                nextId = seed.Substring(0, 1) + letters.Substring(++char2idx, 1) + "001";
            else
            {
                var char1idx = letters.IndexOf(seed.Substring(0, 1));
                nextId = letters.Substring(++char1idx, 1) + "A001";
            }
        }
        return nextId;
    }
