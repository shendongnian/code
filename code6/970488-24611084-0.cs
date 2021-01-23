    using Excel = Microsoft.Office.Interop.Excel;
    Excel.Application excel = new Excel.Application();
    Excel.Workbook workBook = excel.Workbooks.Add();
    
    var inputFile = new FileInfo("Book1.csv"); 
    var sheet = Spreadsheet.Read(inputFile);
    
    workBook.ActiveSheet = sheet; // unsure about this part, but basically you need to transfer data.
    workBook.SaveAs(@"C:\Temp\fromCsv.xls");
    workBook.Close();
