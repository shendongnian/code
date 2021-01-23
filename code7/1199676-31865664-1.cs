           Color colFromHex = System.Drawing.ColorTranslator.FromHtml("#B8C9E9");
           ws.Cells["A1:H16"].Style.Fill.PatternType = ExcelFillStyle.Solid;
           ws.Cells["A1:H16"].Style.Fill.BackgroundColor.SetColor(colFromHex);
           ws.Cells["A1:H16"].Style.Border.Top.Style = ExcelBorderStyle.Medium;
    
 
