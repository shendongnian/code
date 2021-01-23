    using Excel = Microsoft.Office.Interop.Excel;
    
    Excel.Application app = new Excel.Application();
    app.Visible = false; // We don't want it popping into the foreground
    Excel.Workbook wb = app.Workbooks.Open("path to my workbook");
    Excel.Worksheet sheet = wb.Sheets[1] //Change the number to the sheet you want to open. 1 indexed.
    //Get the number of rows containing data
    int lastrow = sheet.UsedRange.Rows.Count; 
    //Get the number of columnss containing data
    int lastcol = sheet.UsedRange.Columns.Count;
    System.Array myValues = null;
    Excel.Range c1;
    Excel.Range c2;
    for(int i = 0; i <= lastrow; i++) {
        c1 = sheet.Cells[i, 1];
        c2 = sheet.Cells[i, lastcol];
        myValues = (System.Array)sheet.get_Range(c1, c2);
        //You would do some processing/storing of your information here
    }
   
    
