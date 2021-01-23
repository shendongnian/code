	var fileinfo = new FileInfo(path);
	if (fileinfo.Exists)
	{
		using (ExcelPackage p = new ExcelPackage(fileinfo))
		{
			//using (stream = new FileStream(path, FileMode.Open, FileAccess.ReadWrite))
			{
				//p.Load(stream);
				ExcelWorksheet ws = p.Workbook.Worksheets.Add(wsName + wsNumber.ToString());
				ws.Cells[1, 1].Value = wsName;
				ws.Cells[1, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
				ws.Cells[1, 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(184, 204, 228));
				ws.Cells[1, 1].Style.Font.Bold = true;
				p.Save();
			}
		}
	}
