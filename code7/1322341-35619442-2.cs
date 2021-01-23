    string pattern3 = @"([^\d]+)";
    string[] strs= Regex.Split(str, pattern3, RegexOptions.Singleline);
    foreach (string s in strs)
    {
        Console.WriteLine(s);
    }
