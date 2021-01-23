    [XmlRoot("testcaseslist")]
    public class TestCasesList
    {
        [XmlElement("testcase")]
        public TestCase[] TestCase { get; set; }
    }
