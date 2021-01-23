    var MyList = new List<excelInventario>();
	using (var pck = new ExcelPackage(fi))
	{
		var workbook = pck.Workbook;
		var worksheet = workbook.Worksheets.Add("Sheet1");
		worksheet.Cells.LoadFromCollection(MyList, true);
		worksheet.Cells[2,3].LoadFromArrays(MyList.Select((r) => r.cols.Cast<object>().ToArray()));
		pck.Save();
	}
