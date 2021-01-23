	[TestMethod]
	public void LoadFromCollection_Test()
	{
		//http://stackoverflow.com/questions/29958463/repeater-data-to-excel-using-epplus
		//Throw in some data
		var dataSet = new List<RowObject>();
		for (var a = 0; a < 20; a++)
			dataSet.Add(new RowObject
			{
				ColumnString = "Row " + a,
				ColumnDateTime = DateTime.Now.AddHours(a)
			});
		//Clear the file
		var newFile = new FileInfo(@"C:\Temp\Temp.xlsx");
		if (newFile.Exists)
			newFile.Delete();
		var i = 0;
		using (var package = new ExcelPackage(newFile))
		{
			var ws = package.Workbook.Worksheets.Add("Sheet1");
			ws.Cells["A1"].LoadFromCollection(dataSet, true);
			package.Save();
		}
	}
	
	public class RowObject
	{
		public string ColumnString { get; set; }
		public DateTime ColumnDateTime { get; set; }
	}
