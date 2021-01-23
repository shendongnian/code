    public static class StringExtensions
    {
        public static string ToKebabCase(this string source)
        {
            if (source is null) return null;
            if(source.Length == 0) return string.Empty;
            if (source.Length == 1) return char.ToLower(source[0]).ToString();
            StringBuilder builder = new StringBuilder();
            for(var i = 0; i < source.Length; i++)
            {
                if (char.IsLower(source[i])) // if current char is already lowercase
                {
                    builder.Append(source[i]);
                }
                else if(i == 0) // if current char is the first char
                {
                    builder.Append(char.ToLower(source[i]));
                }
                else if (char.IsLower(source[i - 1])) // if current char is upper and previous char is lower
                {
                    builder.Append("-");
                    builder.Append(char.ToLower(source[i]));
                }
                else if(i + 1 == source.Length || char.IsUpper(source[i + 1])) // if current char is upper and next char doesn't exist or is upper
                {
                    builder.Append(char.ToLower(source[i]));
                }
                else // if current char is upper and next char is lower
                {
                    builder.Append("-");
                    builder.Append(char.ToLower(source[i]));
                }
            }
            return builder.ToString();
        }
    }
