        using Excel = Microsoft.Office.Interop.Excel;
        Excel.Application excelApp = new Excel.Application();
            // Opening Excel file
        Excel.Workbook excelWorkbook = excelApp.Workbooks.Open
        (@"filePath.xlsx");
        Excel.Worksheet sheet = excelWorkbook.Worksheets.get_Item(1);
        Excel.Range range = sheet.UsedRange;
            //Read value from single cell 
        var cellValue = (string)(sheet.Cells[Row, Col] as Excel.Range).Value;
        System.Diagnostics.Debug.WriteLine(cellValue);
