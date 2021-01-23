    int k = -1;
    foreach (Match m in Regex.Matches(s, "#START#(.*?)#END#", RegexOptions.Singleline | RegexOptions.Compiled))
    {
        k++;
        int k2 = -1;
        Console.WriteLine("Variable " + k + ":");
        foreach (var line in m.Groups[1].Value.Split('\n'))
        {
            Console.WriteLine("Line " + ++k2 + ": " + line);
        }
        Console.WriteLine();
    }
