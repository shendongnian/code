    using Excel=Microsoft.Office.Interop.Excel
    
    var excelApp = (Excel.Application) System.Runtime.InteropServices.Marshal.GetActiveObject("Excel.Application");
    if(excelApp==null)
      excelApp = new Excel.Application();
