    public void Write(tbl_Sale sale,List<SalesModel> saleCollection)
    {  
        Mouse.SetCursor(Cursors.Wait);
    	Excel.Application application = null;
        Workbook workbook = null;
        Worksheet inputSheet = null;
        Range range = null;
        
        try
        {
      		. . .
    		InitializeExcelObjects();
    		. . .
    	}
        finally
        {
           DeinitializeExcelObjects();
           Mouse.SetCursor(Cursors.Arrow);
        }
    }
    
    private void InitializeExcelObjects()
    {
         
    
        application = new Excel.Application();
    
        workbook = application.Workbooks.Add(Type.Missing);
    
        sheets = workbook.Worksheets;
        inputSheet = (Excel.Worksheet)sheets.Item[1];
    }
    
    private void DeinitializeExcelObjects()
    {
        Marshal.ReleaseComObject(inputSheet);
    
        Marshal.ReleaseComObject(sheets);
    
        workbook.Close(false, null, null); 
        Marshal.ReleaseComObject(workbook);
    
        application.DisplayAlerts = false;
        application.Quit();
        Marshal.ReleaseComObject(application);
        application = null;
    }
