    var sb = new StringBuilder();
    for (int i = 0; i < str.Length; i++)
    {
        bool isLetter = char.IsLetterOrDigit(str, i);
        bool isHighSurrogate = char.IsHighSurrogate(str[i]);
        if (isLetter)
        {
            sb.Append(str, i, isHighSurrogate ? 2 : 1);
        }
        if (isHighSurrogate && i + 1 < str.Length && char.IsLowSurrogate(str[i + 1]))
        {
            i++;
        }
    }
    string str2 = sb.ToString();
