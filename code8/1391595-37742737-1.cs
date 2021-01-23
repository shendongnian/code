    var serializer = new XmlSerializer(typeof (TestResultsCollection));
    var testResultsCollection = new TestResultsCollection();
    testResultsCollection.Items = new List<TestResult>
    {
        new TestSuite
        {
            Results = new TestResultsCollection
            {
                Items = new List<TestResult> {new TestCase(), new TestSuite()}
            }
        },
        new TestCase
        {
            Results = new TestResultsCollection
            {
                Items = new List<TestResult> {new TestCase(), new TestSuite()}
            }
        }
    };
    using (var fileStream = File.CreateText("output.xml"))
    {
        serializer.Serialize(fileStream, testResultsCollection);
    }
    using (var fileStream = File.OpenText("output.xml"))
    {
        var deserialized = (TestResultsCollection)serializer.Deserialize(fileStream);
    }
