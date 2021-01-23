    public static class StringExtensions
    {
        public static string ExtractMiddle(this string text, string front, string back)
        {
            text = text.Substring(text.IndexOf(front) + 1);
            return text.Remove(text.IndexOf(back));
        }
    }
