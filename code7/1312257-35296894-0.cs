    [TestFixture("a.txt")]
    [TestFixture("b.txt")]
    [TestFixture("c.txt")]
    public class MyClass
    {
        string _filename;
        public MyClass(string filename)
        {
            _filename = filename;
        }
        [TestFixtureSetUp]
        //[OneTimeSetUp] for NUnit 3
        public void FixtureSetUp()
        {
            PrepareFile(_filename);
        }
        [Test()]
        public void Test()
        {
            var result = YourTestCode();
            Assert.True(result); //whatever you need
        }
    }
