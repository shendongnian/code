    [TestInitialize]
    public void Initialize()
    {
        List<string> fakeSheetNames = new List<string>()
        {
            "Master",
            "A",
            "B",
            "C",
            "__ParentA", 
            "D",
            "wsgParentB", 
            "E",
            "F",
            "__ParentC",
            "__ParentD",
            "G"
        };
        var sheetMockList = new List<IWorksheet>();
        foreach (string name in fakeSheetNames) {
            var tmpMock = new Mock<IWorksheet>();
            tmpMock.Setup(p => p.Name).Returns(name);
            sheetMockList.Add(tmpMock.Object);
        }
        var mockWorksheets = new Mock<IWorksheets>();
        mockWorksheets.Setup(p => p.GetEnumerator()).Returns(sheetMockList.GetEnumerator());
        ...
    }
