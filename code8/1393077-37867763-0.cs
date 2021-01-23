    // MyDisposable an IDisposable with child elements
    private static MyDisposable _parent; 
    
    [OneTimeTearDown]
    public void Teardown()
    {
        if (_parent != null)
        {
            _parent.Dispose();
            _parent = null;
        }
    }
    
    private static IEnumerable<TestCaseData> GetTestCases()
    {
        _parent = new MyDisposable(true);
        return _parent.Children.Select(md => new TestCaseData(md));
    }
    
    [TestCaseSource("GetTestCases")]
    public void TestSafe(MyDisposable myDisposable)
    {
        Assert.IsFalse(myDisposable.HasChildren);
    }
