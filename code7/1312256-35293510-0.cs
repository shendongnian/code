    [TestFixture]
    public class MyClass
    {
        [TestFixtureSetUp]
        //[OneTimeSetUp] for NUnit 3
        public void FixtureSetUp()
        {
            PrepareFile("a.txt");
            PrepareFile("b.txt");
            PrepareFile("c.txt");
        }
        [TestCase("a.txt")]
        [TestCase("b.txt")]
        [TestCase("c.txt")]
        public void Test(string fileName)
        {
            var result = YourTestCode(fileName);
            Assert.True(result); //whatever you need
        }
    }
