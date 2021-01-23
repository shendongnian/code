    using VBA = Microsoft.Vbe.Interop;
    using Excel = Microsoft.Office.Interop.Excel;
    private void ReadExcel()
    {
    	string filePath = @"C:\temp\Macro.xlsm";
    
    	Microsoft.Office.Interop.Excel.Application appExcel = null;
    	Microsoft.Office.Interop.Excel.Workbooks workbooks = null;
    	Microsoft.Office.Interop.Excel.Workbook workbook = null;
    
    	object oMiss = System.Reflection.Missing.Value;
    
    	appExcel = new Microsoft.Office.Interop.Excel.Application();
    	appExcel.DisplayAlerts = true;
    	appExcel.AutomationSecurity = Microsoft.Office.Core.MsoAutomationSecurity.msoAutomationSecurityByUI;
    	// Make the excel visible
    	appExcel.Visible = true;
    	workbooks = appExcel.Workbooks;
    	workbook = workbooks.Open(filePath, oMiss,
    							  oMiss, oMiss,
    							  oMiss, oMiss,
    							  oMiss, oMiss,
    							  oMiss, oMiss,
    							  oMiss, oMiss,
    							  oMiss, oMiss,
    							  oMiss);
    	
    	if (workbook.HasVBProject)  // Has macros
    	{
    		try
    		{
    			// Show "Microsoft Excel Security Notice" prompt
    			var project = workbook.VBProject;
    		}
    		catch (System.Runtime.InteropServices.COMException comex)
    		{
    			// Macro is enabled.
    		}
    	}
    	
    	workbook.Close(true, oMiss, oMiss);
    
    	System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
    	workbook = null;
    	System.Runtime.InteropServices.Marshal.ReleaseComObject(workbooks);
    	workbooks = null;
    	appExcel.Quit();
    	System.Runtime.InteropServices.Marshal.ReleaseComObject(appExcel);
    	appExcel = null;
    }
