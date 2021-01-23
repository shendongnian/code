    public class SomeClass : MemoryCache
    {
        public SomeClass() : base("Test")
        {
        }
        public bool Add(string key, object value)
        {
            return Add(key, value, DateTime.Now.AddDays(1));
        }
    }
    [TestFixture]
    public class TestSomeClass
    {
        [Test]
        public void TestSomeClassMethod1()
        {
            var instance = new SomeClass();
            const string key = "someKey";
            Assert.IsFalse(instance.Contains(key));
            Assert.IsTrue(instance.Add(key, new object()));
            Assert.IsTrue(instance.Contains(key));
            instance.Remove(key);
            Assert.IsFalse(instance.Contains(key));
        }
    }
