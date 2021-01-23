    //This runs the EXCEL.EXE process.
    Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
    ...
    //This makes the EXCEL.EXE quit regardless of RCWs existing in your programm.
    app.Quit();
