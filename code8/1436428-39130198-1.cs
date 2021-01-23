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
        var worksheetMockList = new List<IWorksheet>();
        foreach (string name in fakeSheetNames) {
            var tmpMock = new Mock<IWorksheet>();
            tmpMock.Setup(p => p.Name).Returns(name);
            tmpMock.Setup(p => p.Visible)
                .Returns(parentPrefixes.Any(p => name.StartsWith(p)) ?
                    SheetVisibility.Hidden :
                    SheetVisibility.Visible);
            worksheetMockList.Add(tmpMock.Object);
        }
        var mockWorkSheets = new Mock<IWorksheets>();
        mockWorkSheets.Setup(m => m[It.IsAny<int>()]).Returns<int>(index => worksheetMockList[index]);
        mockWorkSheets.Setup(m => m.GetEnumerator()).Returns(worksheetMockList.GetEnumerator());
        var mockWorkbook = new Mock<IWorkbook>();
        mockWorkbook.Setup(p => p.Worksheets).Returns(mockWorkSheets.Object);
            
        var workbook = mockWorkbook.Object;
            
        var expectedIndex = 1;
        var expected = worksheetMockList[expectedIndex];
        //Act
        var actual = workbook.Worksheets[expectedIndex];
        //Assert
        Assert.AreEqual(expected, actual);
    }
