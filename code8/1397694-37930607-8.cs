    public static class ExtensionMethods
    {
        public static string RemoveNumbers(this string source)
        {
            return Regex.Replace(source, "-?[0-9]+", "");
        }
        public static string GetMessage(this string source)
        {
            if (source.StartsWith("Message: "))
            {
                source = source.Replace("Message: ", "");
                source = Regex.Replace(source, "-?[0-9]+", "").Trim();
            }
            return source;
        }
    }
