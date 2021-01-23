    public sealed class EOComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            if (IsOthers(x)) return 1;
            if (IsOthers(y)) return -1;
            return string.Compare(x, y, StringComparison.Ordinal);
        }
        private static bool IsOthers(string str)
        {
            return string.Compare(str, "others", StringComparison.OrdinalIgnoreCase) == 0;
        }
    }
