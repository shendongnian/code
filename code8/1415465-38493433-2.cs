    public static string ConvertRgbaToHex(string rgba)
    {
        if (!Regex.IsMatch(rgba, @"rgba\((\d{1,3},\s*){3}(0(\.\d+)?|1)\)"))
                throw new FormatException("rgba string was in a wrong format");
        var matches = Regex.Matches(rgba, @"\d+");
        StringBuilder hexaString = new StringBuilder("#");
        for(int i = 0; i < matches.Count - 1; i++)
        {
            int value = Int32.Parse(matches[i].Value);
            hexaString.Append(value.ToString("X"));
        }
        return hexaString.ToString();
    }
