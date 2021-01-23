    [TestClass]
    public class CompareListsFixture
    {
        [TestMethod]
        public void CompareLists()
        {
            var listA = new List<MyObject>
            {
                new MyObject(1,"A", 5), // Matches with 1/A/1
                new MyObject(1,"B", 4),
                new MyObject(2,"A", 3), // Matches with 2/A/4
                new MyObject(2,"C", 2),
            };
            var listB = new List<MyObject>
            {
                new MyObject(1,"A", 1),
                new MyObject(2,"A", 4),
                new MyObject(3,"A", 8),
            };
            var expected = new List<MyObject>
            {
                new MyObject(1,"B", 4),
                new MyObject(2,"C", 2),
            };
            var actual = listA.Except(listB, new MyObjectEqualityComparer());
            CollectionAssert.AreEqual(expected, actual.ToList(), new MyObjectComparer());
        }
    }
