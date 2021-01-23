    public void OpenExcel(string FileName, string SheetName, string CellAddress, string CellValue)
    {
        List<string> SheetNames = new List<string>();
    
        bool Proceed = false;
        Excel.Application xlApp = null;
        Excel.Workbooks xlWorkBooks = null;
        Excel.Workbook xlWorkBook = null;
        Excel.Worksheet xlWorkSheet = null;
        Excel.Sheets xlWorkSheets = null;
    
        xlApp = new Excel.Application();
        xlApp.DisplayAlerts = false;
        xlWorkBooks = xlApp.Workbooks;
        xlWorkBook = xlWorkBooks.Open(FileName);
    
        xlApp.Visible = false;
        xlWorkSheets = xlWorkBook.Sheets;
    
        for (int x = 1; x <= xlWorkSheets.Count; x++)
        {
            xlWorkSheet = (Excel.Worksheet)xlWorkSheets[x];
    
            SheetNames.Add(xlWorkSheet.Name);
    
            if (xlWorkSheet.Name == SheetName)
            {
                Proceed = true;
                Excel.Range xlRange1 = null;
                xlRange1 = xlWorkSheet.Range[CellAddress];
                xlRange1.Value = CellValue;
    
                string value = xlRange1.Value;
                Console.WriteLine(value);
    
                Marshal.FinalReleaseComObject(xlRange1);
                xlRange1 = null;
                xlWorkSheet.SaveAs(FileName);
                break;
            }
    
            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(xlWorkSheet);
            xlWorkSheet = null;
        }
    
        xlWorkBook.Close();
        xlApp.Quit();
    
        ReleaseComObject(xlWorkSheets);
        ReleaseComObject(xlWorkSheet);
        ReleaseComObject(xlWorkBook);
        ReleaseComObject(xlWorkBooks);
        ReleaseComObject(xlApp);
    
        if (Proceed)
        {
            MessageBox.Show("Found sheet, do your work here.");
        }
        else
        {
            MessageBox.Show("Sheet not located");
        }
    
        MessageBox.Show("Sheets available \n" + String.Join("\n", SheetNames.ToArray()));
    }
    
    private void ReleaseComObject(object obj)
    {
        try
        {
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
            obj = null;
        }
        catch (Exception)
        {
            obj = null;
        }
    }
    
    public string GetCellValue(string FileName, string SheetName, string CellAddress)
    {
        string CellValue = "";
    
        Excel.Application xlApp = null;
        Excel.Workbooks xlWorkBooks = null;
        Excel.Workbook xlWorkBook = null;
        Excel.Worksheet xlWorkSheet = null;
        Excel.Sheets xlWorkSheets = null;
    
        xlApp = new Excel.Application();
        xlApp.DisplayAlerts = false;
        xlWorkBooks = xlApp.Workbooks;
        xlWorkBook = xlWorkBooks.Open(FileName);
    
        xlApp.Visible = false;
        xlWorkSheets = xlWorkBook.Sheets;
    
        for (int x = 1; x <= xlWorkSheets.Count; x++)
        {
            xlWorkSheet = (Excel.Worksheet)xlWorkSheets[x];
    
            if (xlWorkSheet.Name == SheetName)
            {
                Excel.Range xlRange1 = null;
                xlRange1 = xlWorkSheet.Range[CellAddress];
                CellValue = xlRange1.Value;
                Marshal.FinalReleaseComObject(xlRange1);
                xlRange1 = null;
                xlWorkSheet.SaveAs(FileName);
                break;
            }
    
            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(xlWorkSheet);
            xlWorkSheet = null;
        }
    
        xlWorkBook.Close();
        xlApp.Quit();
    
        ReleaseComObject(xlWorkSheets);
        ReleaseComObject(xlWorkSheet);
        ReleaseComObject(xlWorkBook);
        ReleaseComObject(xlWorkBooks);
        ReleaseComObject(xlApp);
        return CellValue;
    }
 
