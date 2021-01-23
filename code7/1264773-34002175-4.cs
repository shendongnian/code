    using NUnit.Engine;
    using NUnit.Framework;
    using System.Reflection;
    using System.Xml;
    using System;
    
    public class Program
    {
        static void Main(string[] args)
        {
            // set up the options
            string path = Assembly.GetExecutingAssembly().Location;
            TestPackage package = new TestPackage(path);
            package.AddSetting("WorkDirectory", Environment.CurrentDirectory);
    
            // prepare the engine
            ITestEngine engine = TestEngineActivator.CreateInstance();
            var _filterService = engine.Services.GetService<ITestFilterService>();
            ITestFilterBuilder builder = _filterService.GetTestFilterBuilder();
            TestFilter emptyFilter = builder.GetFilter();
            
            using (ITestRunner runner = engine.GetRunner(package))
            {
                // execute the tests            
                XmlNode result = runner.Run(null, emptyFilter);
            }
        }
    
        [TestFixture]
        public class MyTests
        {
            // ...
        }
    }
