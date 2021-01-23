    double doubleHours = 0.0;
    Excel.Range range = excelWorksheet.Cells[rowCount, columnCount];
    string value = range.Value2.ToString();
    
    if (double.TryParse(value, out doubleHours)) {
        //continue processing
    }
