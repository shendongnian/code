    var lines = new string[] {"-360°", "0 x", "1r", "0,01 m/s", "0,01 m/s²"};
    foreach (var s in lines) 
    {
        var matches = Regex.Matches(s, @"(-?\d*,?\d+)(\s*)([°\w](?:/[\w\u2070-\u209F\u00B9\u00B2\u00B3]+)?)");
        foreach (Match m in matches) {
       		Console.WriteLine("Match:" + m.Value);
     		Console.WriteLine("Group[1]: " + m.Groups[1].Value);
       		Console.WriteLine("Group[2]: " + m.Groups[2].Value);
       		Console.WriteLine("Group[3]: " + m.Groups[3].Value);
        }
    }
