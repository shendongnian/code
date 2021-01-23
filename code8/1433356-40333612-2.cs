    HSSFCellStyle hStyle = (HSSFCellStyle)templateWorkbook.CreateCellStyle();
    hStyle.FillForegroundColor = IndexedColors.Red.Index;
    hStyle.FillPattern = FillPattern.SolidForeground;
    for (int i = 1; i < num; i++)
    {
        dataRow = (HSSFRow)sheet.GetRow(i);
        dataRow.GetCell(10, MissingCellPolicy.CREATE_NULL_AS_BLANK).CellStyle = hStyle;
    }
