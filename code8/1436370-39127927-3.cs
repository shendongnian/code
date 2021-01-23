    [TestMethod]
    public void Mock_Custom_Collection_Using_Moq() {
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
            var worksheet = Mock.Of<IWorksheet>();
            worksheet.Name = name;
            worksheet.Visible = parentPrefixes.Any(p => name.StartsWith(p)) ?
                    SheetVisibility.Hidden :
                    SheetVisibility.Visible;
            worksheetMockList.Add(worksheet);
        }
        var mockWorkbook = new Mock<IWorkbook>();
        mockWorkbook
            .Setup(p => p.Worksheets.GetEnumerator())
            .Returns(() => worksheetMockList.GetEnumerator());
        var workbook = mockWorkbook.Object;
        //Act
        bool IsUserCostWorkbook = false;
        if (workbook.Worksheets.Cast<IWorksheet>()
            .Any(ws => ws.Name.Equals("Master", StringComparison.InvariantCultureIgnoreCase))) {
            IsUserCostWorkbook = true;
        }
        //Assert            
        Assert.IsTrue(IsUserCostWorkbook);
    }
