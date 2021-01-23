    //get color from this cell
    var rgb = ws.Cells[1, 2].Style.Fill.BackgroundColor.Rgb;
    //Convert to system.drawing.color
    var color = System.Drawing.ColorTranslator.FromHtml("#" + rgb);
    //set color in this cell
    ws.Cells[1, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
    ws.Cells[1, 1].Style.Fill.BackgroundColor.SetColor(color);
