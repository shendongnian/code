    internal static class CollectionComparer {
    internal static void AssertAreEqual<T>(List<T> expected, List<T> actual) 
        {
            Assert.AreEqual(expected.Count, actual.Count);
            for (var i = 0; i < expected.Count; i++) 
            {
                CollectionComparer.AssertAreEqual(expected[i], actual[i]);
            }
        }
    }
