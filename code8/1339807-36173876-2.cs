    public static bool CheckNonEmptyStringsForEquality(params string[] strings)
    {
        string target = strings.FirstOrDefault(s => !string.IsNullOrEmpty(s));
        if (target == null)
            return false;
        return strings.All(s => string.IsNullOrEmpty(s) || s == target);
    }
