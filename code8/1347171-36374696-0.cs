    public static IEnumerable<string> ConcatWithLimit(IEnumerable<string> words, int maxLineLength)
    {
        var sb = new StringBuilder();
        foreach (string word in words)
        {
            if (sb.Length + word.Length > maxLineLength)
            {
                yield return sb.ToString().TrimEnd();
                sb.Clear();
            }
            sb.Append(word).Append(" ");
        }
        if (sb.Length > 0)
            yield return sb.ToString().TrimEnd();
    }
