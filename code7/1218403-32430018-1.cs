    var regBackups = new Regex(@"\r\n((?>\r\n.+){5})(?!\r\n.)",
        RegexOptions.Compiled
    );
        
    foreach (Match m in regBackups.Matches(strBackups))
    {
        Console.WriteLine("=============================");
        Console.WriteLine(m.Groups[1].Value);
        Console.WriteLine("=============================");
    }
