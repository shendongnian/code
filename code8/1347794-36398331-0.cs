    public static class ExtensionMethods
    {
        public static string Replace(this string s, char[] separators, string newVal)
        {
            var sb = new StringBuilder(s);
            foreach (char ch in separators)
            {
                string target = new string(ch, 1);
                sb.Replace(target, newVal);
            }
            return sb.ToString();
        }
    }
