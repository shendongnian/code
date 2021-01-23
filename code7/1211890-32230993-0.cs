    private char[] alphabets = {'A','B','C', 'D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'};    
    var input = "AB123456789C123412341234B123";
    var result = input.SplitAndKeep(alphabets).ToList();
    
    public static class StringExtensions
    {
        public static IEnumerable<string> SplitAndKeep(this string s, char[] delims)
        {
            int start = 0, index;
            while ((index = s.IndexOfAny(delims, start)) != -1)
            {
                if (index - start > 0)
                    yield return s.Substring(start, index - start);
                yield return s.Substring(index, 1);
                start = index + 1;
            }
            if (start < s.Length)
            {
                yield return s.Substring(start);
            }
        }
    }
