    using Microsoft.Office.Interop.Excel;
    using System.Runtime.InteropServices;
    Application app = new Application();
    Workbooks books = clsExcelApplication.Workbooks;
    Workbook book = books.Open("...");
    Sheets sheets = book.Sheets;
    Worksheet sheet = sheets["..."];
    ...
    //Revese order. Using FinalReleaseComObject is even more dangerous. 
    //You might release an object used inside excel
    //code which might lead to some dreadful internal exceptions.
    Marshal.ReleaseComObject(sheet);
    Marshal.ReleaseComObject(sheets);
    Marshal.ReleaseComObject(book);
    Marshal.ReleaseComObject(books);
    app.Quit();
    Marshal.ReleaseComObject(app);
    
