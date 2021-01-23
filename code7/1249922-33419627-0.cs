    [ContractAnnotation("source:null => true")]
    public static bool IsNullOrWhitespace(this string source)
    {
        return string.IsNullOrWhiteSpace(source);
    }
