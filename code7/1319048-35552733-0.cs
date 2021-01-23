    /// <summary>
    /// Run a macro from an xlsb file on another excel file
    /// </summary>
    /// <param name="ExcelFile">The excel file to run the macro on</param>
    /// <param name="MacroFileLocation">The xlsb file the macro is saved in</m>
    /// <param name="Macro">The macro name to run (e.g. Module1.Example)</param>
    static void Test(string ExcelFile, string MacroFileLocation, string Macro)
    {
        Application xlApp = new Application(); //Excel app
        Workbook xlWbk = null;
        try
        {
            xlWbk = xlApp.Workbooks.Open(ExcelFile);
            
            string MacroCommand = "'" + MacroFileLocation + "'!" + Macro;
            xlApp.Run(MacroCommand);
        }
        finally
        {
            //Clean up
            if (xlWbk != null)
                try
                {
                    xlWbk.Close(true);
                }
                catch
                {
                    //Couldn't save - consider alerting user
                    xlWbk.Close(false);
                }
            xlApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWbk);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);
                
            xlWbk = null;
            xlApp = null;
        }
    }
