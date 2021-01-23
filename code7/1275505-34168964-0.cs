    public static string AlphaToAscii(string str)
    {
        var result = string.Empty;
        foreach (char c in str)
        {
            if (c >= 65 && c <= 122)
                result += (int)c;
            else if (c >= 48 && c <=57)
                result += c;
        }
        return result;
    }
