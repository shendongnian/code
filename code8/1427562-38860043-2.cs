    var cell = worksheet.Cells["E1"];
    cell.Style.Font.Name = "Calibri";
    cell.Style.Font.Size = 11;
    cell.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#ffc7ce"));
    cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
    cell.Font.Color.SetColor(ColorTranslator.FromHtml("#be0006"));
