    var rgx = new Regex(@"^([^_]+)_([^\d.]+)([\d.]+\d+)\.(.*)$");
    var matches = rgx.Matches(input);
    if (matches.Count > 0)
    {
        Console.WriteLine("{0}", matches[0].Groups[0]);  // All input string
        Console.WriteLine("{0}", matches[0].Groups[1]);  // ABCD
        Console.WriteLine("{0}", matches[0].Groups[2]);  // EFGH
        Console.WriteLine("{0}", matches[0].Groups[3]);  // 20120700.0
        Console.WriteLine("{0}", matches[0].Groups[4]);  // xml
    }
