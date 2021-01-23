          Color colFromHex = System.Drawing.ColorTranslator.FromHtml("#B8C9E9");
          ws.Cells.Style.Fill.PatternType = ExcelFillStyle.Solid;
          ws.Cells.Style.Fill.BackgroundColor.SetColor(colFromHex);
          ws.Cells.Style.Border.Top.Style = ExcelBorderStyle.Medium;
          // . . . . .
     
