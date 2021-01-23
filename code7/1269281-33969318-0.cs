    public static string Method(string input)
    {
        var split = input.Split(new[] {'/'}, StringSplitOptions.RemoveEmptyEntries);
        if (split.Length == 0) return input;
        return split[0];
    }
