    public static string ToSentence(this string Source)
    {
        Source = Regex.Replace(Source, "((?<!^)[A-Z][a-z])", " $1");
        Source = Regex.Replace(Source, "([a-z])([A-Z])", "$1 $2");
        return Source;
    }
