    [TestFixture]
    public class _TestClass
    {
            [TestFixtureSetUp]
            public void Setup()
            {
               //Clearup can be here before start of the tests. But not Recommended
            }
    
            [Test]
            public void _Test1()
            {
            }
            [Test]
            public void _Test2()
            {
            }
    
            [TestFixtureTearDown]
            public void CleanUp()
            {
                //I will recommend to clean up after all the tests complete
            }
    }
