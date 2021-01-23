    using NUnit.Engine;
    using NUnit.Framework;
    using System.Reflection;
    using System.Xml;
    using System;
    
    public class Program
    {
        static void Main(string[] args)
        {
            ITestEngine engine = TestEngineActivator.CreateInstance();
            ITestFilterService _filterService = engine.Services.GetService<ITestFilterService>();
            TestPackage package = new TestPackage(Assembly.GetExecutingAssembly().Location);
            package.AddSetting("WorkDirectory", Environment.CurrentDirectory);
            using (ITestRunner runner = engine.GetRunner(package))
            {
                ITestFilterBuilder builder = _filterService.GetTestFilterBuilder();
                XmlNode result = runner.Run(null, builder.GetFilter());
            }
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
