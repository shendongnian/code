    private class MyComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            return x.Substring(5).CompareTo(y.Substring(5));
        }
    }
