	[TestMethod]
	public void ListOfList_Test()
	{
		//http://stackoverflow.com/questions/33825995/how-to-use-loadfromcollection-in-epplus-with-a-list-containing-another-list-insi
		//Throw in some data
		var MyList = new List<TestExtensions.excelInventario>();
		for (var i = 0; i < 10; i++)
		{
			var row = new TestExtensions.excelInventario
			{
				codigo = Path.GetRandomFileName(),
				nombre = i.ToString(),
				cols = new List<decimal> {i, (decimal) (i*1.5), (decimal) (i*2.5)}
			};
			MyList.Add(row);
		}
		//Create a test file
		var fi = new FileInfo(@"c:\temp\ListOfList.xlsx");
		if (fi.Exists)
			fi.Delete();
		using (var pck = new ExcelPackage(fi))
		{
			var workbook = pck.Workbook;
			var worksheet = workbook.Worksheets.Add("Sheet1");
			worksheet.Cells.LoadFromCollection(MyList, true);
			worksheet.Cells[2,3].LoadFromArrays(MyList.Select((r) => r.cols.Cast<object>().ToArray()));
			pck.Save();
		}
	}
