	[TestMethod]
	public void Table_To_Object_Test()
	{
		//Create a test file
		var fi = new FileInfo(@"c:\temp\Table_To_Object.xlsx");
		using (var package = new ExcelPackage(fi))
		{
			var workbook = package.Workbook;
			var worksheet = workbook.Worksheets.First();
			var ThatList = worksheet.Tables.First().ConvertTableToObjects<ExcelData>();
			foreach (var data in ThatList)
			{
				Console.WriteLine(data.Id + data.Name + data.Gender);
			}
			package.Save();
		}
	}
