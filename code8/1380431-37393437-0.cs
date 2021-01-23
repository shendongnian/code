    public static class String
    {
        public static bool containsAtLeastXNonDigit(string s, int nbOfDigit)
        {
            return s.Count(!char.IsDigit) >= nbOfDigit;
        }
    }
