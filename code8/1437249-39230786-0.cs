    using NUnit.Engine;
    using NUnit.Framework;
    using System;
    using System.Reflection;
    using System.Xml;
    
    namespace NunitWebRunner
    {
        public partial class _default : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                // set up the options
                string path = Assembly.GetExecutingAssembly().Location;
                TestPackage package = new TestPackage(path);
                package.AddSetting("ProcessModel", "Single");
                package.AddSetting("DomainUsage", "None");
    
                // prepare the engine
                ITestEngine engine = TestEngineActivator.CreateInstance();
                var _filterService = engine.Services.GetService<ITestFilterService>();
                ITestFilterBuilder builder = _filterService.GetTestFilterBuilder();
                TestFilter emptyFilter = builder.GetFilter();
    
                using (ITestRunner runner = engine.GetRunner(package))
                {
                    // execute the tests            
                    XmlNode result = runner.Run(null, emptyFilter);
                    lblTest.Text = result.InnerText;
                }
            }
        }
    
        [TestFixture]
        public class TemplateTestClass
        {
            [Test]
            public void TestThatPasses()
            {
                Assert.IsTrue(true);
            }
    
            [Test]
            public void TestThatFails()
            {
                Assert.AreEqual(4, 5);
            }
    
            [Test]
            [Ignore("Ignored")]
            public void IgnoredeTest()
            {
                Assert.IsTrue(false);
            }
        }
    }
