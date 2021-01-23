    public static class TextExtensions
    {
        public static IEnumerable<string> TextElements(this string s)
        {
            // StringInfo.GetTextElementEnumerator is a .Net 1.1 class that doesn't implement IEnumerable<string>, so convert
            if (s == null)
                yield break;
            var enumerator = StringInfo.GetTextElementEnumerator(s);
            while (enumerator.MoveNext())
                yield return enumerator.GetTextElement();
        }
        public static string Reverse(this string s)
        {
            if (s == null)
                return null;
            return s.TextElements().Reverse().Aggregate(new StringBuilder(s.Length), (sb, c) => sb.Append(c)).ToString();
        }
        public static IEnumerable<string> ToLines(this string text)
        {
            if (text == null)
                yield break;
            using (var sr = new StringReader(text))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }
        public static string ToText(this IEnumerable<string> lines)
        {
            if (lines == null)
                return null;
            return lines.Aggregate(new StringBuilder(), (sb, l) => sb.AppendLine(l)).ToString();
        }
        public static string ReverseLines(this string s)
        {
            if (s == null)
                return null;
            return s.ToLines().Reverse().Select(l => l.Reverse()).ToText();
        }
    }
