    public static string GetTextBetween(string content, string start, string end)
    {
        if (content.Length == 0 || start.Length == 0 || end.Length == 0)
            return string.Empty;
        string contentRemove = content.Remove(0, content.IndexOf(start, StringComparison.Ordinal) + start.Length);
        return contentRemove.Substring(0, contentRemove.IndexOf(end, StringComparison.Ordinal)).Trim();
    }
