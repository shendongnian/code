    // Load the data into the cells
    Int32 rowIdx = 1;
    foreach (String line in tab.Lines)
    {
        String[] cellTexts = line.Split(TAB);
        Int32 colIdx = 1;
        foreach (String cellText in cellTexts)
        {
            DateTime dateValue;
            Double doubleValue;
            if(DateTime.TryParse(cellText,out dateValue))
            {
                sheet.Cells[rowIdx, colIdx].Value = dateValue;
            }
            else if (Double.TryParse(cellText, out doubleValue))
            {
                sheet.Cells[rowIdx, colIdx].Value = doubleValue;
            }
            else
            {
                sheet.Cells[rowIdx, colIdx].Value = cellText;
            }
            colIdx++;
        }
        rowIdx++;
    }
