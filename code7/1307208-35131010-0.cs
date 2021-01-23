 `  
        public void WebTest_CodedStep()
        {
        // Object for missing (or optional) arguments.
        object oMissing = System.Reflection.Missing.Value;
        // Create an instance of Microsoft Excel
        Excel.ApplicationClass oExcel = new Excel.ApplicationClass();
        // Make it visible
        oExcel.Visible = true;
        // Define Workbooks
        Excel.Workbooks oBooks = oExcel.Workbooks;
        Excel._Workbook oBook = null;
        // Get the file path
        string path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        path = path + "\\Worksheet02.csv";
        //Open the file, using the 'path' variable
        oBook = oBooks.Open(path, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing,  oMissing, oMissing, oMissing, oMissing, oMissing, oMissing);
        // Run the macro, "First_Macro"
        RunMacro(oExcel, new Object[]{"Worksheet01.xlsm!First_Macro"});
        // Quit Excel and clean up.
        oBook.Close(false, oMissing, oMissing);
        System.Runtime.InteropServices.Marshal.ReleaseComObject (oBook);
        oBook = null;
        System.Runtime.InteropServices.Marshal.ReleaseComObject (oBooks);
        oBooks = null;
        oExcel.Quit();
        System.Runtime.InteropServices.Marshal.ReleaseComObject (oExcel);
        oExcel = null;
        //Garbage collection
        GC.Collect();
    }
    private void RunMacro(object oApp, object[] oRunArgs)
    {
        oApp.GetType().InvokeMember("Run", System.Reflection.BindingFlags.Default | System.Reflection.BindingFlags.InvokeMethod, null, oApp, oRunArgs);
    }
