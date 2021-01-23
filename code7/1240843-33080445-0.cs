     Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
    if (xlApp == null)
    {
       System.Windows.MessageBox.Show("Excel is not properly installed!!");
       return;
    }
    Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
    Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
 
    //After creating the new Workbook, next step is to write content to worksheet
        
     xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
    //Bind your columns and rows as you like in the worksheet. For example : 
    xlWorkSheet.Cells[1, 1] = "Column 1, Row 1 data ";
    //Then re initiate the xlworksheet and do the same as before.
    xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(2);
    xlWorkSheet.Cells[1, 1] = "Column 1, Row 1 data ";// 2nd sheet data
    
    //Save the excel file after creating as much sheet you want.
    xlWorkBook.SaveAs(path + "\\" + exlFilename); // here the path/ location and the filename to be provided.
