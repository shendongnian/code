    public static class StringExtensions
    {
        public static string ToCamelCase(this string source)
        {
            var parts = source
                .Split(new[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
            return parts
                .First().ToLower() +
                String.Join("", parts.Skip(1).Select(ToCapital));
        }
        public static string ToCapital(this string source)
        {
            return String.Format("{0}{1}", char.ToUpper(source[0]), source.Substring(1).ToLower());
        }
    }
