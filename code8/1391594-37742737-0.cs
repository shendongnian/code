    public class TestResult
    {
        ...
        [XmlElement("results")]
        public TestResultsCollection Results { get; set; }
        ...
    }
    public class TestCase : TestResult
    {
    }
    public class TestSuite : TestResult
    {
        [XmlAttribute("type")]
        public String Type { get; set; }
    }
    [XmlRoot("test-results")]
    public class TestResultsCollection
    {
        [XmlElement("test-case", Type = typeof(TestCase))]
        [XmlElement("test-suite", Type = typeof(TestSuite))]
        public List<TestResult> Results { get; set; }
    }
