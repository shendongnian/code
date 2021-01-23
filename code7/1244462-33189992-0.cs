    class CollectionAssertComperator : IComparer
    {
        public int Compare(object x, object y)
        {
            CollectionAssert.AreEqual((ICollection)x, (ICollection)y);
            return 0;
        }
    }
