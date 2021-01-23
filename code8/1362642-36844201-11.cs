    //This runs the EXCEL.EXE process.
    Microsoft.Office.Interop.Excel.Application app = 
        new Microsoft.Office.Interop.Excel.Application();
    //This locks the excel file either for reading or writing 
    //depending on parameters.
    Microsoft.Office.Interop.Excel.Workbook book = app.Workbooks.Open(...);
    ...
    //Explicitly closing the book is a good thing. EXCEL.EXE is alive 
    //but the excel file gets released.
    book.Close();
    //This lets the EXCEL.EXE quit after you release all your references to RCWs
    //and let GC collect them and thus release the underlying COM objects. 
    //EXCEL.EXE does not close immediately after this though.
    app.Quit();
    app = null;
