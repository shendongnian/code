    public static class StringExtensions
    {
        public static int MatchWord(this string container, bool caseInsensitive, params string[] values)
        {
            int result = -1;
            int counter = 0;
            foreach (string s in values)
            {
                if (s != null && string.Compare(container, s, caseInsensitive) == 0)
                {
                    result = counter;
                    break;
                }
                counter++;
            }
            return result;
        }
    }
