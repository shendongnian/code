    public static class StringExtension
    {
        public static string CapitalizeFirst(this string s)
        {
            bool IsNewSentense = true;
            var result = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (IsNewSentense && s[i] != ' ' && s[i] != ',' && s[i] == '\n')
                {
                    result = result + s[i].ToString().ToUpper();
                    IsNewSentense = false;
                }
                else
                    result = result + s[i];
                if (s[i] == '!' || s[i] == '?' || s[i] == '.')
                {
                    IsNewSentense = true;
                }
            }
            return result;
        }
    }
