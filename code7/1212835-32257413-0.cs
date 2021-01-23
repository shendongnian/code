    static bool letterTest(string pathway)
    {
        char[] badChars = Path.GetInvalidPathChars();
        return pathway.All(c => !badChars.Contains(c));
        // or
        // return !pathway.Any(c => badChars.Contains(c));
    }
