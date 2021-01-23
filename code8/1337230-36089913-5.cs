    public static class StringExtension
    {
        public static string CapitalizeFirst(this string s)
        {
            bool IsNewSentense = true;
            var result = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                if (IsNewSentense && char.IsLetter(s[i]))
                {
                    result.Append (char.ToUpper (s[i]));
                    IsNewSentense = false;
                }
                else
                    result.Append (s[i]);
                if (s[i] == '!' || s[i] == '?' || s[i] == '.')
                {
                    IsNewSentense = true;
                }
            }
            return result.ToString();
        }
    }
