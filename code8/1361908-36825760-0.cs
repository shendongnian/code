    public static string ToSentence(this string value)
    {
        int length = value.Length;
        if (length == 0) return string.Empty;
        var sb = new StringBuilder(value[0].ToString(), length);
        char currentChar;
        for (int ubound = length - 2, i = 1; i <= ubound; ++i)
        {
            currentChar = value[i];
            if (Char.IsUpper(currentChar) && (Char.IsLower(value[i - 1]) || Char.IsLower(value[i + 1])))
                sb.Append(' ', 1);
            sb.Append(currentChar, 1);
        }
        sb.Append(value[length - 1], 1);
        return sb.ToString();
    }
