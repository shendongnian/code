    public static class Ex
    {
        public static string PathForBatchFile(this string input)
        {
            return input.Contains(" ") ? string.Format("\"{0}\"", input) : input;
        }
    }
