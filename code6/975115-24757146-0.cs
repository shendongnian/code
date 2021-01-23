    static bool Valid(string input)
    {
        const string Pattern = @"PHY(\d{8})";
        const int Max = 10000000;
        var match = Regex.Match(input, Pattern);
        if (match.Success)
        {
            int value = int.Parse(match.Groups[1].Value);
            if (value <= Max)
            {
                return true;
            }
        }
        return false;
    }
