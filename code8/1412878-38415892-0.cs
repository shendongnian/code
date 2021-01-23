    Excel.Application xlApp = null;
    while(xlApp == null)
    {
        try
        {
            xlApp = (Excel.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Excel.Application");
        }
        catch (System.Runtime.InteropServices.COMException ex)
        {
            // no more instances/error, exit out of loop
            break;
        }
        
        // do whatever with the instance
        Workbook wb = xlApp.ActiveWorkbook; 
        wb.Save();
        GC.Collect();
        GC.WaitForPendingFinalizers();
        wb.Close(); 
        Marshal.FinalReleaseComObject(wb);  
        xlApp.Quit();    
        Marshal.FinalReleaseComObject(xlApp);
        // set null to continue loop
        xlApp = null;
    }
