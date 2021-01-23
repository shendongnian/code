    //right border
     sheet.Range[beginRow, beginCol, endRow, endCol].Style.Borders[BordersLineType.EdgeRight].LineStyle = LineStyleType.Thin;
    sheet.Range[beginRow, beginCol, endRow, endCol].Style.Borders.Color = Color.Black;
    //left border
    sheet.Range[beginRow, beginCol, endRow, endCol].Style.Borders[BordersLineType.EdgeLeft].LineStyle = LineStyleType.Thin;
    sheet.Range[beginRow, beginCol, endRow, endCol].Style.Borders.Color = Color.Black;
