    public static int Countline(string file, string lineSeperator)
    {
        string text = File.ReadAllText(file);
    
        return System.Text.RegularExpressions.Regex.Matches(text, lineSeperator).Count;
    }
