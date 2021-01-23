    private void importToolStripMenuItem_Click(object sender, EventArgs e)
    {
        openFileDialog1.Filter = "Excel WorkBooks (*.xlsx)|*.xlsx";
        openFileDialog1.FilterIndex = 1;
        openFileDialog1.Multiselect = false;
        if(openFileDialog1.ShowDialog() == DialogResult.OK)
        {
            string path = openFileDialog1.FileName;
            // Call another method that wraps all the Excel COM stuff
            // That prevents debug builds from confusing the lifetime of COM references
            DoExcelStuff(path);
            // When back here, all the Excel references should be out of scope
            // Run the GC (twice) to clean up all COM references
            // (This can be pulled out into a helper method somewhere)
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
    private void DoExcelStuff(string path)
    {
        // All your Excel COM interop goes here
   
        string empRange = "D4";
        string emptxid = "K4";
        object oMissing = System.Reflection.Missing.Value;
            
        // ... variable declarations
        xlApp = new oExcel.Application();
        // More xlApp, workbooks etc...
        // Done - tell Excel to close
        xlApp.Quit();
        // No need for Marshal.ReleaseComObject(...) 
        // or setting variables to null here! 
    }
