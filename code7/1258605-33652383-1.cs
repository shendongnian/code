    public static IEnumerable<string> SpecialSplit(
        this string str, char delimiter, char beginEndEscape)
    {
        int beginIndex = 0;
        int length = 0;
        bool escaped = false;
        foreach (char c in str)
        {
            if (c == beginEndEscape)
            {
                escaped = !escaped;
            }
                
            if (!escaped && c == delimiter)
            {
                yield return str.Substring(beginIndex, length);
                beginIndex += length + 1;
                length = 0;
                continue;
            }
            length++;
        }
        yield return str.Substring(beginIndex, length);
    }
