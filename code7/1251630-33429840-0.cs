    if (Directory.GetFiles(subdir).Length == 0)   //if no image in that sub directory
    {
        ws.Cells["A1:A3"].Merge = true;
        ws.Cells["A1:A3"].Style.VerticalAlignment = ExcelVerticalAlignment.Top;
        ws.Cells["A1:A3"].Style.Border.Top.Style = ExcelBorderStyle.Thin;
        ws.Cells["A1:A3"].Style.Border.Left.Style = ExcelBorderStyle.Thin;
        ws.Cells["A1:A3"].Style.Border.Right.Style = ExcelBorderStyle.Thin;
        ws.Cells["A1:A3"].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
        ws.Cells["A1:A3"].Style.Fill.PatternType = ExcelFillStyle.Solid;
        ws.Cells["A1:A3"].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#f0f3f5"));
        ws.Cells["A1:A3"].Value = "content not found";
    }
    
    foreach (string img in Directory.GetFiles(subdir))
    {
        // Your else code
    }
