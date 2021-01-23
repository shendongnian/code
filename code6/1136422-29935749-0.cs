    public void ExcelLandscapeFormat()
    {
     try 
     { 
        ((Microsoft.Office.Interop.Excel._Worksheet)  
        excelWbook.ActiveSheet).PageSetup.Orientation =  
        Microsoft.Office.Interop.Excel.XlPageOrientation.xlLandscape;
    
        excelWbook.ExportAsFixedFormat(XlFixedFormatType.xlTypePDF,  
        Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\" + output); 
     } 
     catch
     { }
    }
