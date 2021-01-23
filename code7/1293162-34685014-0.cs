    public static class Ex
    {
        public static string PathForBatchFile(this string input)
        {
            return input.Contains(" ") ? $"\"{input}\"" : input;
        }
    }
