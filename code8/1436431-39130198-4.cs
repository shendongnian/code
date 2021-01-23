    [TestMethod]
    public void Mock_Readonly_Indexer_Property() {
        //Arrange
        var parentPrefixes = new List<string>() { "__", "wsg" };
        var fakeSheetNames = new List<string>(){
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
        //Worksheets
        var fakeWorkSheetsList = new List<IWorksheet>();
        foreach (string name in fakeSheetNames) {
            var tmpMock = new Mock<IWorksheet>();
            tmpMock.Setup(p => p.Name).Returns(name);
            tmpMock.Setup(p => p.Visible)
                .Returns(parentPrefixes.Any(p => name.StartsWith(p)) ?
                    SheetVisibility.Hidden :
                    SheetVisibility.Visible);
            fakeWorkSheetsList.Add(tmpMock.Object);
        }
        var mockWorkSheets = new Mock<IWorksheets>();
        mockWorkSheets.Setup(m => m[It.IsAny<int>()])
            .Returns<int>(index => fakeWorkSheetsList[index]);
        mockWorkSheets.Setup(m => m.GetEnumerator())
            .Returns(fakeWorkSheetsList.GetEnumerator());
        //Assuming a Count property exists
        mockWorkSheets.Setup(m => m.Count).Returns(fakeWorkSheetsList.Count);
        //Workbook
        var mockWorkbook = new Mock<IWorkbook>();
        mockWorkbook.Setup(p => p.Name).Returns("Name");
        mockWorkbook.Setup(p => p.FullName).Returns("FullName");
        mockWorkbook.Setup(p => p.Worksheets).Returns(mockWorkSheets.Object);
        //Workbooks
        var fakeWorkbooksList = new List<IWorkbook>() { mockWorkbook.Object };
        var mockWorkbooks = new Mock<IWorkbooks>();
        mockWorkbooks.Setup(m => m[It.IsAny<int>()])
            .Returns<int>(index => fakeWorkbooksList[index]);
        mockWorkbooks.Setup(m => m.GetEnumerator())
            .Returns(fakeWorkbooksList.GetEnumerator());
        mockWorkbooks.Setup(m => m.Count).Returns(fakeWorkbooksList.Count);
        //WorkbookSet
        var mockWorkbookSet = new Mock<IWorkbookSet>();
        mockWorkbookSet.Setup(m => m.Workbooks).Returns(mockWorkbooks.Object);
        var workbookSet = mockWorkbookSet.Object;
        var expectedWorkBooksIndex = 0;
        var expectedWorkSheetIndex = 1;
        var expected = fakeWorkSheetsList[expectedWorkSheetIndex];
        //Act
        var actual = workbookSet
            .Workbooks[expectedWorkBooksIndex]
            .Worksheets[expectedWorkSheetIndex];
        //Assert
        Assert.AreEqual(expected, actual);
        foreach (IWorkbook workbook in workbookSet.Workbooks) {
            Assert.IsTrue(workbook.Worksheets.Count > 0);
        }
    }
