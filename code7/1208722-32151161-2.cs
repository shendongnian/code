    public enum Letters { A, B, C };
    public static class ConversionExtensions
    {
        public static string ConvertToString(this Letters letter)
        {
            if (letter == Letters.A) { return "A"; }
            if (letter == Letters.B) { return "B"; }
            if (letter == Letters.C) { return "C"; }
            return "?";
        }
        public static Letters ConvertToLetter(this string s)
        {
            if (s == "A") { return Letters.A; }
            if (s == "B") { return Letters.B; }
            return Letters.C;
        }
    }
