    public static string IntToBase(int value, char[] basechars)
    {
        string result = string.Empty;
        int conversion = basechars.Length;
        do
        {
            result = basechars[value % conversion] + result;
            value = value / conversion;
        }
        while (value > 0);
        return result;
    }
