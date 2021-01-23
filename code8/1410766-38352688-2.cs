	Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
	var wbs = excel.Workbooks;
	Workbook wb = wbs.Add(XlSheetType.xlWorksheet);
	Worksheet ws = (Worksheet)excel.ActiveSheet;
	List<object> data = new List<object>
	data.Add("Folder Names");
	for (int row = 0; row <= count; row++)
	{
		data.Add(Namelist);
	}
	Excel.Range rng = (Excel.Range)ws.Range[ws.Cells[1, 1], ws.Cells[1,count + 2]];
	rng.Value = data.ToArray();
	excel.Visible = true;
