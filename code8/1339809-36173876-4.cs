    public static bool CheckNonEmptyStringsForEquality(params string[] strings)
    {
        string target = strings.FirstOrDefault(s => !string.IsNullOrEmpty(s));
        return strings.All(s => string.IsNullOrEmpty(s) || s == target);
    }
