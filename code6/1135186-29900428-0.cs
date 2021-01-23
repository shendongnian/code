    string pattern = "T1.([^ ]+) < 1901,( .*)";
    Regex rgx = new Regex(pattern);
    for (int i = 0; i < lines.Count; i++)
    {
        Match m = rgx.Match(lines[i]);
        if (m.Success == true) {
            lines[i] = rgx.Replace(lines[i],"T2." + m.Groups[1] + m.Groups[2]);
        }
    }
