    public class TestClass
    {
        string _value = null;
        [XmlElement("Value", IsNullable=true)]
        public string Value
        {
            get { return _value; }
            set
            {
                _value = value;
                ValueSpecified = true;
            }
        }
        [XmlIgnore]
        public bool ValueSpecified { get; set; }
        public static void Test()
        {
            Test(new TestClass());
            Test(new TestClass() { Value = null });
            Test(new TestClass() { Value = "Something" });
        }
        static void Test(TestClass test)
        {
            var xml = test.GetXml();
            Debug.WriteLine(xml);
            var testBack = xml.LoadFromXML<TestClass>();
            Debug.Assert(testBack.Value == test.Value && testBack.ValueSpecified == test.ValueSpecified);
        }
    }
