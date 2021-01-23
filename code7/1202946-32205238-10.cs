    using NSubstitute;
    using Microsoft.Office.Interop.Excel;
    
    public static class ExcelMockFactory
    {
    	private const string MockSheetName = "MockSheet";
    	private const int NumMockValues = 12;
    
    	public static Range Cell
    	{
    		get
    		{
    			var mockCell = Substitute.For<Range>();
    			mockCell.Address.Returns("$A$1");
    			mockCell.Formula = "=2+2";
    			mockCell.ToString().Returns(mockCell.Formula.ToString());
    			mockCell.Worksheet.Returns(Sheet);
    			mockCell.Worksheet.Name.Returns(MockSheetName);
    
    			return mockCell;
    		}
    	}
    
    	public static Worksheet Sheet
    	{
    		get
    		{
    			var mockSheet = Substitute.For<Worksheet>();
    			mockSheet.Name = MockSheetName;
    			mockSheet.Visible = XlSheetVisibility.xlSheetVisible;
    
    			return mockSheet;
    		}
    	}
    
    	public static Workbook Workbook()
    	{
    		return Workbook(1);
    	}
    
    	public static Workbook Workbook(int numSheets)
    	{
    		var listOfSheets = new List<Worksheet>();
    		var mockSheets = Substitute.For<Sheets>();
    		mockSheets.Count.Returns(listOfSheets.Count);
    
    		for (int i = 0; i < numSheets; i++)
    		{
    			listOfSheets.Add(Sheet);
    			listOfSheets[i].Name = MockSheetName + (i + 1);
    			mockSheets[i].Returns(listOfSheets[i]);
    		}
    
    		(mockSheets as IEnumerable).GetEnumerator().Returns(listOfSheets.GetEnumerator());
    		mockSheets.Item[Arg.Any<int>()].Returns(listOfSheets[Arg.Any<int>()]);
    		mockSheets.get_Item(Arg.Any<int>()).Returns(listOfSheets[Arg.Any<int>()]);
    		mockSheets[Arg.Any<int>()].Returns(listOfSheets[Arg.Any<int>()]);
    
    		var mockBook = Substitute.For<Workbook>();
    		mockBook.Worksheets.Returns(mockSheets);
    		mockBook.Sheets.Returns(mockSheets);
    		mockBook.DefaultPivotTableStyle.Returns(listOfSheets);
    
    		return mockBook;
    	}
    
    	public static Application Excel()
    	{
    		return Excel(1);
    	}
    
    	public static Application Excel(int numSheets)
    	{
    		var excelApp = Substitute.For<Application>();
    		var mockBook = Workbook(numSheets);
    		excelApp.ActiveWorkbook.Returns(mockBook);
    
    		return excelApp;
    	}
    }
