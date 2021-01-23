    public static void ApplyBackgroundColorsPerRow(
        this ExcelWorksheet worksheet, 
        int startRow, int startColumn, int endRow, int endColumn, 
        List<System.Drawing.Color> colors)
    {
        if (startRow > endRow)
        {
            throw new ArgumentException("startRow cannot be greater than endRow", "startRow");
        }
        int numberOfColors = colors.Count;
        for (int row = startRow; row <= endRow; row++)
        {
            using (ExcelRange range = worksheet.Cells[row, startColumn, row, endColumn])
            {
                range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                range.Style.Fill.BackgroundColor.SetColor(colors[(row - startRow) % numberOfColors]);
            }
        }
    }
