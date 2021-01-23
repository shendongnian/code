    [ConsoleOutToTestWriter] // redirect Console.Out into "Output" property per test
    public class ClassTest
    {
        [Test]
        [TestWriter] // adds "Output" property
        public void MyTest()
        {
            Console.WriteLine("test 123");
            Console.WriteLine("321 test");
        }
        [Test]
        [TestWriter]
        public void MyTest2()
        {
            // this console output will be written to this test's own "Output"
            Console.WriteLine("test2 123");
            Console.WriteLine("321 test2");
        }
    }
