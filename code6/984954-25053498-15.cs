    private static double? getDoubleOrNull(string text)
    {
        if(string.IsNullOrWhiteSpace(text))
            return null;
        else
            return double.Parse(text);
    }
