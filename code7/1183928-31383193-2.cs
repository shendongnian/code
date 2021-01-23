    public static class SearchEngine
    {
        public static double CompareStrings(string val1, string val2)
        {
            if ((val1.Length == 0) || (val2.Length == 0)) return 0;
            if (val1 == val2) return 100;
            double maxLength = Math.Max(val1.Length, val2.Length);
            double minLength = Math.Min(val1.Length, val2.Length);
            int charIndex = 0;
            for (int i = 0; i < minLength; i++) { if (val1.Contains(val2[i])) charIndex++; }
            return Math.Round(charIndex / maxLength * 100);
        }
        public static List<string> Search(this string values[], string query, double threshold)
        {
            List<string> result = new List<string>();
            for(int i = 0; i < values.Length) 
            { 
               if(CompareStrings(values[i], query) > threshhold) result.Add(values[i]);
            }
            return result;
        {
    }
