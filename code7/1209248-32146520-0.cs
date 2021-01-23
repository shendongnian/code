    public static class StringExtensions
    {
        public static int CaseInsensitveCompare(this string s, string stringToCompare)
        {
            return String.Compare(s, stringToCompare, StringComparison.InvariantCultureIgnoreCase);
        }
    }
