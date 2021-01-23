    public static string CleanupHeaders(string _Col)
    {
        _Col = _Col.Replace(@"\\0K", ""); // Replaces the exact already escaped \\ value.
        _Col = _Col.Replace(@"\\b", "");
        _Col = _Col.Replace(@"\\0", "");
        return _Col;
    }
