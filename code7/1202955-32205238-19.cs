    [TestMethod]
    public void ShouldFindFormulaInSheet()
    {
    	//Arrange
    	Range cell = MockFactory.Cell,;
    	cell.Address.Returns("$A$1");
    	cell.Formula.ToString().Returns(string.Format("=Add(\"{0}\",\"{1}\")", 2, 2);
    	var sheet = MockFactory.Sheet;
    	sheet.Name.Returns("MockSheet");
    	sheet.Range(cell.Address).Returns(cell);
        
    	//Act
    	var usedRange = Substitute.For<Range>();
    	usedRange.Value2 = "usedRange";
    	usedRange.Find("Add", LookIn: XlFindLookIn.xlFormulas).Returns(cells[0]);
    	usedRange.FindNext(cell).Returns(cell);
    	sheet.UsedRange.Returns(usedRange);
    
    	Assert.AreEqual...
    }
