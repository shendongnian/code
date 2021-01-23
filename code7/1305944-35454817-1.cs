    private void button1_Click(object sender, EventArgs e)
    {
         Microsoft.Office.Interop.Excel.Application excelApplication = StartExcel();
        if (excelApplication != null)
        {
            excelApplication.ActiveCell.Value = "Hello World";
        }
    }
    [DllImport("user32.dll", SetLastError = true)]
    static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint processId);
    [DllImport("ole32.dll")]
    private static extern int GetRunningObjectTable(int reserved, out IRunningObjectTable prot);
    private Microsoft.Office.Interop.Excel.Application StartExcel()
    {
        // Maximum number of attempts to look for started Excel Application
        const int maxAttempts = 3;
        // Number of milliseconds to wait between attempts to look for started Excel Application
        const int waitTimeMS = 200;
        
        Microsoft.Office.Interop.Excel.Application result = null;
        // Start Excel
        var process = Process.Start("Excel.exe");
        process.WaitForInputIdle();
        // Try to find started Excel Application
        int currentAttempt = 1;
        while ((result == null) && (currentAttempt <= maxAttempts))
        {
            // Wait between attempts 
            if(currentAttempt != 1)
            {
                Thread.Sleep(waitTimeMS);
            }
            // List all running Excel automation objects and find the one with the same process id
            IRunningObjectTable lRunningObjectTable = null;
            IEnumMoniker lMonikerList = null;
            try
            {
                // Query Running Object Table 
                if (GetRunningObjectTable(0, out lRunningObjectTable) == 0 && lRunningObjectTable != null)
                {
                    // List Monikers
                    lRunningObjectTable.EnumRunning(out lMonikerList);
                    // Start Enumeration
                    lMonikerList.Reset();
                    // Array used for enumerating Monikers
                    IMoniker[] lMonikerContainer = new IMoniker[1];
                    IntPtr lPointerFetchedMonikers = IntPtr.Zero;
                    // foreach Moniker
                    while (lMonikerList.Next(1, lMonikerContainer, lPointerFetchedMonikers) == 0)
                    {
                        object lComObject;
                        lRunningObjectTable.GetObject(lMonikerContainer[0], out lComObject);
                        // Check the object is an Excel workbook
                        if (lComObject is Microsoft.Office.Interop.Excel.Workbook)
                        {
                            Microsoft.Office.Interop.Excel.Workbook lExcelWorkbook = (Microsoft.Office.Interop.Excel.Workbook)lComObject;
                            // Get the Process ID for the Window Handle 
                            uint processId;
                            GetWindowThreadProcessId(new IntPtr(lExcelWorkbook.Application.Hwnd), out processId);
                            if (processId == process.Id)
                            {
                                // Correct automation object found, return Application
                                result = lExcelWorkbook.Application;
                                break;
                            }
                        }
                    }
                }
            }
            finally
            {
                // Release ressources
                if (lRunningObjectTable != null) Marshal.ReleaseComObject(lRunningObjectTable);
                if (lMonikerList != null) Marshal.ReleaseComObject(lMonikerList);
            }
            currentAttempt++;
        }
        return result;
    }
