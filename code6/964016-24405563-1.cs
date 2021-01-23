    private static string ParseText(string text, string separator)
    {
        List<int> commentsIndexes = AllIndexesOf(text, separator);
        // Collect all the substrings that are in between separators and need to be removed.
        List<string> substringsToRemove = new List<string>();
        for (int i = 0; i < commentsIndexes.Count; i += 2)
        {
            int start = commentsIndexes[i];
            int len   = (commentsIndexes[i+1] - commentsIndexes[i]) + separator.Length; // Get separator length so it is included in the substring that will be removed.
            substringsToRemove.Add(text.Substring(start, len));
        }
        foreach (string str in substringsToRemove)
        {
            // Note you cannot use remove here 
            // because it will change the indexes values in the string
            text = text.Replace(str, string.Empty); 
        }
        return text;
    }
