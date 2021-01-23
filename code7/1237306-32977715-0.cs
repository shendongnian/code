	var fi = new FileInfo(@"c:\temp\Html_Fragment.xlsx");
	using (var pck = new ExcelPackage(fi))
	{
		var wb = pck.Workbook;
		var ws = wb.Worksheets.FirstOrDefault();
		ExcelRange er = ws.Cells[1,1];
		var hyperlink = er.Hyperlink;
		Console.WriteLine(er.Value);
        Console.WriteLine("{{Value: {0}, Hyperlink: {1}}}", er.Value, er.Hyperlink.AbsoluteUri);
	}
