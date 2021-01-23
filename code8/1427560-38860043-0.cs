    var cell = worksheet.Cells["E1"];
    cell.Style.Font.Name = "Calibry";
    cell.Style.Font.Size = 11;
    cell.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(156, 0, 6));
    cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
