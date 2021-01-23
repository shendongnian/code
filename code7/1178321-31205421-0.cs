    [TestFixture]
    public class MyTestTests
    {
        [Test]
        public void MyTest()
        {
            using (ShimsContext.Create())
            {
                ShimFoo.TryBarStringStringOut = (string input, out string output) =>
                {
                    output = "Yada yada yada";
                    return false;
                };
            }
        }
    }
