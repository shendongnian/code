    public static string AlphaToAscii(string str)
    {
        var result = string.Empty;
        foreach (char c in str)
        {
             if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z'))
                result += (int)c;
            else if (c >= '0' && c <= '9')
                result += c;
        }
        return result;
    }
