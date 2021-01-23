    //get style
    var style = ws.Cells[400, 1].Style;
    
    //If color from System colors or palette
    if (!string.IsNullOrEmpty(style.Fill.BackgroundColor.Rgb))
    {
       //Convert to system.drawing.colow
       var color = System.Drawing.ColorTranslator.FromHtml("#" + style.Fill.BackgroundColor.Rgb);
       //set color in this cell
       ws.Cells[1, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
       ws.Cells[1, 1].Style.Fill.BackgroundColor.SetColor(color);
    }
    else if (!string.IsNullOrEmpty(style.Fill.BackgroundColor.Theme))
    {
       //No idea how to get color from Theme
    }
