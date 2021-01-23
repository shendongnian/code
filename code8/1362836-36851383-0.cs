    using (var excel = new ExcelPackage())
    {
        var ws = excel.Workbook.Worksheets.Add("sheet1");
        ws.Cells[1, 2].Value = "light grey";
        ws.Cells[1, 2].Style.Fill.PatternType = ExcelFillStyle.Solid;
        ws.Cells[1, 2].Style.Fill.BackgroundColor.SetColor(Color.LightGray);
        excel.SaveAs(new System.IO.FileInfo(@"C:\temp\temp.xlsx"));
    }
