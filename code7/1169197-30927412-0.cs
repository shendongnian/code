    public static string[] SplitDelimiter(this string str, char delimiter, int count = 0, StringSplitOptions options = StringSplitOptions.None)
    {
        int toCount = count == 0 ? count = str.Length : toCount = count;
        return str.Split(new[] { delimiter }, toCount, options);
    }
