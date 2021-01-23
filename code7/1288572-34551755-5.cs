    var fileInfo = new FileInfo(@"c:\temp\Expand_Table.xlsx");
	using (var pck = new ExcelPackage(fileInfo))
	{
		var workbook = pck.Workbook;
		var worksheet = workbook.Worksheets.First();
		
		//Added 11th data row assuming the table is from A1 to C11 (Header row + 10 data rows)
		worksheet.Cells["A12"].Value = 10;
		worksheet.Cells["B12"].Value = 100;
		worksheet.Cells["C12"].Value = Path.GetRandomFileName();
		var tbl = worksheet.Tables["TestTable1"];
		var oldaddy = tbl.Address;
		var newaddy = new ExcelAddressBase(oldaddy.Start.Row, oldaddy.Start.Column, oldaddy.End.Row + 1, oldaddy.End.Column);
		tbl.Address = newaddy;
		pck.Save();
	}
