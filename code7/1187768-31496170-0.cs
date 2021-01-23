    private void button1_Click(object sender, EventArgs e)
    {
        CloseExcelWorkbook("TestReport.xlsx");
    }
    //put the following abbreviation to the "using" block: using Excel = Microsoft.Office.Interop.Excel;
    internal void CloseExcelWorkbook(string workbookName)
    {
        try 
        {	        
            Process[] plist = Process.GetProcessesByName("Excel", ".");
            if (plist.Length  > 1)
                throw new Exception("More than one Excel process running.");
            else if (plist.Length == 0)
                 throw new Exception("No Excel process running.");
               
            Object obj = Marshal.GetActiveObject("Excel.Application");
            Excel.Application excelAppl = (Excel.Application)obj;
            Excel.Workbooks workbooks = excelAppl.Workbooks;
            foreach (Excel.Workbook wkbk in workbooks )
            {
                if (wkbk.Name == workbookName)
                    wkbk.Close();
            }
            //dispose
            //workbooks.Close(); //this would close all workbooks
            GC.Collect();
            GC.WaitForPendingFinalizers();
            if (workbooks != null)
                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(workbooks);
            //excelAppl.Quit(); //would close the excel application
                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(excelAppl);
            GC.Collect();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
