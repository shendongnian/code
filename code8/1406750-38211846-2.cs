	public static void Createxlsx(string filename) 
	{
		MemoryStream stream = new MemoryStream();
		//create a package 
		using (var package = new ExcelPackage(stream)) // disposing ExcelPackage also disposes the above MemoryStream
		{
			var worksheet = package.Workbook.Worksheets.Add("worksheet");
			package.Save();
		
			// see the various ways to create/open a file, Create is just one of them
			// open the file stream
			using(var file = System.IO.File.Open("C:\\ConsoleApplicationXLSX\\" + filename + ".xlsx", System.IO.FileMode.CreateNew))
			{
				stream.Position = 0; // reset the position of the memory stream
				stream.CopyTo(file); // copy the memory stream to the file stream
			}
		}
	}
