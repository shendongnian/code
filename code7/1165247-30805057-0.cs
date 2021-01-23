    using Excel = Microsoft.Office.Interop.Excel;
    internal static bool ExportDGV(DataGridView DGV, List<string> selectedCustomerList, string path, string fileName, string exportName, int exportType, string mailSubject)
    {
        string totalPath;
        //Create an Excel application instance
        Excel.Application excelApp = new Excel.Application();
        Excel.Workbook excelWorkBook = excelApp.Application.Workbooks.Add();
        Excel._Worksheet worksheet = null;
        excelApp.Visible = false;
        worksheet = excelWorkBook.ActiveSheet;
    
        //set headers
        for (int i = 1; i < DataGridView.Columns.Count + 1; i++)
        {
        worksheet.Cells[1, i] = DGV.Columns[i - 1].HeaderText;
        }
        createList(worksheet, DGV);
   
        //Create excel with the choosen name
        Worksheet sheet1 = excelWorkBook.Worksheets[1];
        worksheet.Name = fileName;
        totalPath = path + "/" + fileName + ".xlsx";
                 
        //if path exist add a number
        totalPath = directoryExist(totalPath, path, fileName);
        //Save exel and Quit exelApp 
        
        excelWorkBook.SaveAs(totalPath);
        excelWorkBook.Close();
        excelApp.Quit();
    }
