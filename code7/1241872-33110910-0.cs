    [TestFixture]
    public class Tests()
    {
        [TestCase]
        public void MyTest()
        {
            var span = new TestSpan()
            using(span)
            {
                // Do test stuff
            }
        }
    }
    public class TestSpan: IDisposable
    {
        TestSpan()
        {
            // Do Test Setup Stuff
        }
        Dispose()
        {
            // Do Test Cleanup Stuff
        }
    }
