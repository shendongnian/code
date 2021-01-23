    static class StringExtensions
    {
        public static string tr(this string st,
                string orig, string replacement)
        {
            var sb = new StringBuilder(st.Length);
            foreach (char c in st)
            {
                bool replaced = false;
                for (int i = 0; i < orig.Length; ++i)
                {
                    if (replacement.Length > i && c == orig[i])
                    {
                        sb.Append(replacement[i]);
                        replaced = true;
                        break;
                    }
                }
                if (!replaced) sb.Append(c);
            }
            return sb.ToString();
        }
    }
