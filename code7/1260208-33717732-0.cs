        Try this..
        
        Excel.Range workSheetUsedRange = sSheet.UsedRange;
        
        string formNumber = string.Empty;
        
        if ((workSheetUsedRange.Cells[rowIndex, columnIndex] as Excel.Range).Value2 != null)
                        formNumber = (workSheetUsedRange.Cells[rowIndex, columnIndex] as Excel.Range).Value2.ToString();
                    excelUtil.SaveWorkBook(file, ref workbook);
    
    You can use this code to get the value of any cell using rowIndex and columnIndex.
    It is a good practise to check if the value of the cell that you are trying to read is null. If the value is null, you get an exception.
