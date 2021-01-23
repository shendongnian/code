    Application xlApp = new Application();
    Workbook wb = xlApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
    Worksheet ws = wb.Worksheets[1];
    
    var yearCode = xlApp.International[XlApplicationInternational.xlYearCode];
    var monthCode = xlApp.International[XlApplicationInternational.xlMonthCode];
    var dayCode = xlApp.International[XlApplicationInternational.xlDayCode];
    
    ws.Cells[1, 1].NumberFormat = string.Format("{0}{1}.{2}{3}.{4}{5}{6}{7}", monthCode, monthCode, dayCode, dayCode, yearCode, yearCode, yearCode, yearCode);
