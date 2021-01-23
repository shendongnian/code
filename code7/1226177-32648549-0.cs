    public static class ExtensionMethods
    {
        public static string ToJS(this bool value)
        {
            return value.ToString().ToLowerInvariant();
        }
    }
