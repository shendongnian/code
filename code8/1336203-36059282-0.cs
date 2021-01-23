    [Test]
    public void CanSortWithOthersAtEnd()
    {
        List<string> a = new List<string> { "z", "y", "x", "others", "b", "a", "c" };
        EOComparer c = new EOComparer();
        a.Sort(c.Compare);
        CollectionAssert.AreEqual(new [] {"a","b","c","x","y","z","others"},a);
    }
    public sealed class EOComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            if (string.Compare("others", x, StringComparison.OrdinalIgnoreCase) == 0) return 1;
            if (string.Compare("others", y, StringComparison.OrdinalIgnoreCase) == 0) return -1;
            return string.Compare(x, y, StringComparison.Ordinal);
        }
    } 
