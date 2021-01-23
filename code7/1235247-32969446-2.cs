    public class TestClass
    {
        [XmlElement("testTag.01")]
        public testTag01 TestTag { get; set; }
        public static void Test()
        {
            Test(new TestClass { TestTag = new testTag01 { NV = "123123" } });
            Test(new TestClass { TestTag = new testTag01 { NV = "123123", SomeEnum = SomeEnum.SomeValue } });
        }
        private static void Test(TestClass test)
        {
            var xml = test.GetXml();
            var test2 = xml.LoadFromXML<TestClass>();
            Console.WriteLine(test2.GetXml());
            Debug.WriteLine(test2.GetXml());
            if (test2.TestTag.NV != test.TestTag.NV)
            {
                throw new InvalidOperationException("test2.TestTag.NV != test.TestTag.NV");
            }
        }
    }
