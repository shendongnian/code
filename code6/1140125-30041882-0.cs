    /// <summary>
    /// Returns the text located between the start and end text within content
    /// </summary>
    public static string GetStringInBetween(string content, string start, string end)
    {
        var startIndex = content.IndexOf(start) + start.Length;
        return content.Substring(startIndex, content.IndexOf(end, startIndex) - startIndex);
    }
