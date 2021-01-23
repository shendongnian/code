    using NUnit.Framework;
    using System.Reflection;
    
    class Program
    {
        static void Main(string[] args)
        {
            string path = Assembly.GetExecutingAssembly().Location;
            NUnit.ConsoleRunner.Program.Main(new[] { path });
        }
    
        [TestFixture]
        public class MyTests
        {
            [Test]
            public void MyTest1()
            {
                int i = 3;
                Assert.AreEqual(3, i);
            }
        }
    }
