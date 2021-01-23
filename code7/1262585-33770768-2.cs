        ...
        string s = sb.ToString();
        int intDivisibleByEight = s.Length % 8;
        int intPadRight = (8 - intDivisibleByEight) % 8;
        char pad = '0';
        s = s.PadRight(s.Length + intPadRight, pad);
        var list = Enumerable
            .Range(0, s.Length / 8)
            .Select(i => s.Substring(i * 8, 8))
            .ToList();
        var res = string.Join(" ", list);
        // DEBUG: echo results for testing.
        Console.WriteLine("");
        Console.WriteLine("String provided: {0}", strMessage);
        Console.WriteLine("String provided total length: {0}", s.Length);
        Console.WriteLine("Hex equivalent of string provided: {0}", sb.ToString());
        Console.WriteLine("Hex in 8-digit chunks: {0}", res.ToString());
        Console.WriteLine("======================================================");
