    public static string IntToLetters(int value)
    {
        string result = string.Empty;
        while (--value >= 0)
        {
            result = (char)('A' + value % 26) + result;
            value /= 26;
        }
        return result;
    }
