    //Save File Locally
    System.IO.File.WriteAllBytes(saveFileDialog.FileName, Report.FileArray);
    var fileLocation = saveFileDialog.InitialDirectory + saveFileDialog.FileName;
 
     Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
    // Open Workbook Using Excel Interop Dll
    Workbook wb = excel.Workbooks.Open(fileLocation);
    Worksheet ws1 = wb.Worksheets.get_Item("English");
    //Make Changes To WorkBook
    ws1.Range["E5"].Value = StartDate;
    ws1.Range["G5"].Value = EndDate;
    // Save Only
    wb.Save();
