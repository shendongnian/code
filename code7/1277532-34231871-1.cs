    [TestClass]
    public class DeepCloneTests
    {
        [TestMethod]
        public void ReferencesAreNotMaintained()
        {
            var object1 = new GenList() { Col1 = "a", Col2 = "b" };
            var cloned = object1.DeepClone();
            Assert.AreEqual(object1.Col1, cloned.Col1);
            Assert.AreEqual(object1.Col2, cloned.Col2);
            cloned.Col1 = "c";
            cloned.Col2 = "d";
            Assert.AreNotEqual(object1.Col1, cloned.Col1);
            Assert.AreNotEqual(object1.Col2, cloned.Col2);
        }
    }
