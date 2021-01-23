    public void DoMyExcelStuffAndCleanup()
    {
        DoMyExcelStuff();
        // Call GC twice to ensure that cleanup after cycles happens immediately
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();
        GC.WaitForPendingFinalizers();
    }
    public void DoMyExcelStuff()
    {
        Application excelApplication = ...
        // Here you access all those Excel objects ...
        // No need for Marshal.ReleaseComObject(...)
        // No need for ... = null
        excelApplication.Quit();
    }
