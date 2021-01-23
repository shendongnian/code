	[TestMethod]
	public void Object_Type_Write_Test()
	{
		//http://stackoverflow.com/questions/31537981/using-epplus-how-can-i-generate-a-spreadsheet-where-numbers-are-numbers-not-text
		var existingFile = new FileInfo(@"c:\temp\temp.xlsx");
		if (existingFile.Exists)
			existingFile.Delete();
		//Some data
		var list = new List<Object[]>
		{
			new object[]
			{
				"111.11",
				111.11,
				DateTime.Now
			}
		};
		using (var package = new ExcelPackage(existingFile))
		{
			var ws = package.Workbook.Worksheets.Add("Sheet1");
			ws.Cells[1, 1, 2, 2].Style.Numberformat.Format = "0";
			ws.Cells[1, 3, 2, 3].Style.Numberformat.Format = "[$-F400]h:mm:ss\\ AM/PM";
			//This will cause numbers in string to be stored as string in excel regardless of cell format
			ws.Cells["A1"].LoadFromArrays(list);
			//Have to go through the objects to deal with numbers as strings
			for (var i = 0; i < list.Count; i++)
			{
				for (var j = 0; j < list[i].Count(); j++)
				{
				
					if (list[i][j] is string)
						ws.Cells[i + 2, j + 1].Value = Double.Parse((string) list[i][j]);
					else if (list[i][j] is double)
						ws.Cells[i + 2, j + 1].Value = (double)list[i][j];
					else
						ws.Cells[i + 2, j + 1].Value = list[i][j];
				}
			}
			package.Save();
		}
	}
