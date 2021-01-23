    [DllImport("ole32.dll")]
    private static extern int GetRunningObjectTable(int reserved, out IRunningObjectTable prot);
    private void button1_Click(object sender, EventArgs e)
    {
        IRunningObjectTable lRunningObjectTable = null;
        IEnumMoniker lMonikerList = null;
        try
        {
            // Query Running Object Table 
            if (GetRunningObjectTable(0, out lRunningObjectTable) != 0 || lRunningObjectTable == null)
            {
                return;
            }
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
                if (lComObject is Microsoft.Office.Interop.Excel.Application)
                {
                    Microsoft.Office.Interop.Excel.Application lExcelApplication = (Microsoft.Office.Interop.Excel.Application)lComObject;
                    // Show the Window Handle 
                    MessageBox.Show("Found Excel Application with Window Handle " + lExcelWorkbook.Application.Hwnd);
                }
            }
        }
        finally
        {
            // Release ressources
            if (lRunningObjectTable != null) Marshal.ReleaseComObject(lRunningObjectTable);
            if (lMonikerList != null) Marshal.ReleaseComObject(lMonikerList);
        }
    }
