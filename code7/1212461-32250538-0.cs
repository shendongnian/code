    var keys = new List<string>() { @"\+", "-", "TEXT", @"\s" };
    var pattern = string.Format("(?:{0})", string.Join("|", keys));
    Regex rx = null;
    try
    {
        rx = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
        var text = "TEXT+TEXT";
        if (rx.IsMatch(text))
            Console.WriteLine(string.Format("\"{0}\" is valid.", text));
        else
            Console.WriteLine(string.Format("\"{0}\" is invalid.", text));
    }
    catch (ArgumentException ae)
    {
        Console.WriteLine(string.Format("Error parsing {0}: {1}", pattern, ae.Message));
    }
