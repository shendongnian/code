    public static class ExtensionMethods
    {
        public static string RemoveNumbers(this string source)
        {
            return Regex.Replace(source, "-?[0-9]+", "").Trim();
        }
    }
