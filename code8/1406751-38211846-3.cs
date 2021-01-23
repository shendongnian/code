	public static void Createxlsx(string filename) 
	{
		using(var file = System.IO.File.Open("C:\\ConsoleApplicationXLSX\\" + filename + ".xlsx", System.IO.FileMode.CreateNew))
		using (var package = new ExcelPackage(file)) // disposing ExcelPackage also disposes the above MemoryStream
		{
			var worksheet = package.Workbook.Worksheets.Add("worksheet");
			package.Save();
		}
	}
