    public static IEnumerable<string> SpecialSplit(
        this string str, char delimiter, char beginEndEscape, char singleEscape)
    {
        StringBuilder builder = new StringBuilder();
        bool escapedSequence = false;
        bool previousEscapeChar = false;
        foreach (char c in str)
        {
            if (c == singleEscape)
            {
                if (previousEscapeChar)
                {
                    builder.Append(singleEscape);
                }
                previousEscapeChar = !previousEscapeChar;
                continue;
            }
            if (c == beginEndEscape && !previousEscapeChar)
            {
                escapedSequence = !escapedSequence;
            }
            if (!escapedSequence && !previousEscapeChar && c == delimiter)
            {
                yield return builder.ToString();
                builder.Clear();
                continue;
            }
            builder.Append(c);
            previousEscapeChar = false;
        }
        yield return builder.ToString();
    }
