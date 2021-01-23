    private void ReleaseComObjects(bool isQuitting)
    {
        try
        {
            if (isQuitting)
            {
                workbook.Close(false, missing, missing); 
                excelApplication.Quit();
            }
            Marshal.ReleaseComObject(workbooks);
            Marshal.ReleaseComObject(workbook);
            if (worksheets != null) Marshal.ReleaseComObject(worksheets);
            Marshal.ReleaseComObject(worksheet);
            Marshal.ReleaseComObject(excelApplication);
            workbook = null;
            worksheets = null;
            worksheet = null;
            excelApplication = null;
        }
        catch { }
        finally { GC.Collect(); }
    }
    private void ReleaseComObjects()
    {
        ReleaseComObjects(false);
    }
