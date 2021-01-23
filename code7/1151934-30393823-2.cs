    public static string RemoveSurrogatePairs(string str, string replacementCharacter = "?")
    {
        if (str == null)
        {
            return null;
        }
        StringBuilder sb = null;
        for (int i = 0; i < str.Length; i++)
        {
            char ch = str[i];
            if (char.IsSurrogate(ch))
            {
                if (sb == null)
                {
                    sb = new StringBuilder(str, 0, i, str.Length);
                }
                sb.Append(replacementCharacter);
                // If there is a high+low surrogate, skip the low surrogate
                if (i + 1 < str.Length && char.IsHighSurrogate(ch) && char.IsLowSurrogate(str[i + 1]))
                {
                    i++;
                }
            }
            else if (sb != null)
            {
                sb.Append(ch);
            }
        }
        return sb == null ? str : sb.ToString();
    }
