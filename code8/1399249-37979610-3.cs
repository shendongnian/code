    Regex re = new Regex("\w+");
    foreach (var line in File.ReadLines(filename))
    {
        var matches = re.Matchs(line);
        foreach (var m in matches)
        {
            if (hashSetOfValues.Contains(m))
            {
                // output match
            }
        }
    }
