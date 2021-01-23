    var pattern = @"(\d+)((,\s*|\s+)|$)";
    const int RegexTimeoutSeconds = 1;
    var matches = Regex.Matches(mystr, pattern, RegexOptions.None, TimeSpan.FromSeconds(RegexTimeoutSeconds));
    var doubles = new List<double>();
    foreach (Match match in matches)
    {
        var group = match.Groups[1];
        var d = Convert.ToDouble(group.Value);
        doubles.Add(d);
    }
