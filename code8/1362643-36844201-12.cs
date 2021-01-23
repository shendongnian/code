    using Microsoft.Office.Interop.Excel;
    using System.Runtime.InteropServices;
    Application app = new Application();
    Workbooks books = clsExcelApplication.Workbooks;
    Workbook book = books.Open("...");
    Sheets sheets = book.Sheets;
    Worksheet sheet = sheets["..."];
    
    ...
    
    //Trying to be as explicit as we can.
    book.Сlose();
    //Revese order. Using FinalReleaseComObject is even more dangerous. 
    //You might release an object used inside excel
    //code which might lead to some dreadful internal exceptions.
    int remainingRefCount;
    remainingRefCount = Marshal.ReleaseComObject(sheet);
    remainingRefCount = Marshal.ReleaseComObject(sheets);
    remainingRefCount = Marshal.ReleaseComObject(book);
    remainingRefCount = Marshal.ReleaseComObject(books);
    app.Quit();
    remainingRefCount = Marshal.ReleaseComObject(app);
    
