    // MyDisposable an IDisposable with child elements
    private static MyDisposable _parent; 
    // This will be run once when the fixture is finished running
    [OneTimeTearDown]
    public void Teardown()
    {
        if (_parent != null)
        {
            _parent.Dispose();
            _parent = null;
        }
    }
    // This will be run once per test which uses it, prior to running the test
    private static IEnumerable<TestCaseData> GetTestCases()
    {
        // Create your data without a 'using' statement and store in a static member
        _parent = new MyDisposable(true);
        return _parent.Children.Select(md => new TestCaseData(md));
    }
    // This method will be run once per test case in the return value of 'GetTestCases'
    [TestCaseSource("GetTestCases")]
    public void TestSafe(MyDisposable myDisposable)
    {
        Assert.IsFalse(myDisposable.HasChildren);
    }
