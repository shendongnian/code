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
	  
		int tamcolumnas = 10; // excelin[0].cols.Count;
		using (ExcelPackage package = new ExcelPackage(fi))
		{
			ExcelWorksheet hoja = package.Workbook.Worksheets.Add("Comparativo unidades contadas VS stock");
			hoja.Cells["A1"].Value = "CODART";
			hoja.Cells["B1"].Value = "NOMBRE";
			for (int i = 0; i < tamcolumnas; i++)
			{
				hoja.Cells[1, i + 3].Value = "COL" + (i + 1);
			}
			//var MyList = new List<TestExtensions.excelInventario>();
			hoja.Cells.LoadFromCollection(MyList, true); 
          //hoja.Cells[2, 3].LoadFromArrays(MyList.Select((r) => r.cols.Cast<object>).ToArray()));
			hoja.Cells[2, 3].LoadFromArrays(MyList.Select((r) => r.cols.Cast<object>().ToArray()));
			package.Save();
		}
	}
