    var regBackups = new System.Text.RegularExpressions.Regex("(?:\r\n){2}");
    var result = regBackups.Split(strBackups);
    
    foreach (var c in result)
    {
        Console.WriteLine("=============================");
        Console.WriteLine(c);
        Console.WriteLine("=============================");
    }
