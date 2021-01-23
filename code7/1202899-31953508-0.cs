    Excel.Application app = new Excel.Application();
    Excel.Workbooks workbooks = app.Workbooks;
    Excel.Workbook workbook = workbooks.Open(templatePath);
    Excel.Worksheet worksheet = workbook.Worksheets[1];
    
    //do stuff to worksheet here
    
    System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
    System.Runtime.InteropServices.Marshal.ReleaseComObject(workbooks);
    System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
    System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
