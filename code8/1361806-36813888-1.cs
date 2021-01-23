    private static string SanitizeVersionStringFromUnit(string version)
    {
        var santizedString = new string(version.Cast<char>().Where(char.IsLetterOrDigit).ToArray());
        return santizedString;
    }
