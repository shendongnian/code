    [TestCase(new[] { "a", "b" }, new[] { "a", "b" })]
    [TestCase(new[] { "b", "a" }, new[] { "a", "b" })]
    [TestCase(new[] {"others"}, new[] {"others"})]
    [TestCase(new[] {"a", "others"}, new[] {"a", "others"})]
    [TestCase(new[] {"others", "a"}, new[] {"a", "others"})]
    [TestCase(new[] {"others", "x"}, new[] {"x", "others"})]
    [TestCase(new[] {"Others", "x"}, new[] {"x", "Others"})]
    [TestCase(new[] {"z", "y", "x", "others", "b", "a", "c"}, new[] {"a", "b", "c", "x", "y", "z", "others"})]
    [TestCase(new[] { "othersz", "others" }, new[] { "othersz", "others" })]
    public void CanSortWithOthersAtEnd(string[] input, string[] expectedSorted)
    {
        var a = new List<string>(input);
        var c = new EOComparer();
        a.Sort(c.Compare);
        CollectionAssert.AreEqual(expectedSorted, a);
    }
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
