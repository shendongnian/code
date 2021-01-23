    Range range = ws.Range["A1:C5"];
    Formatting rangeFormatting = range.BeginUpdateFormatting();
    Borders rangeBorders = rangeFormatting.Borders;
    rangeBorders.LineStyle = XlLineStyle.xlContinuous;
    rangeBorders[XlBordersIndex.xlEdgeTop].Weight = 10d;
    rangeBorders.ColorIndex = XlRgbColor.rgbCrimson;
    range.EndUpdateFormatting(rangeFormatting);
