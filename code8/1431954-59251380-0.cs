        public void ExecuteExcelMacro(string sourceFile)
        {
            ExcelApp.Application ExcelApp = new ExcelApp.Application();
            ExcelApp.DisplayAlerts = false;
            ExcelApp.Visible = false;
            ExcelApp.AutomationSecurity = Microsoft.Office.Core.MsoAutomationSecurity.msoAutomationSecurityLow;
            ExcelApp.Workbook ExcelWorkBook = ExcelApp.Workbooks.Open(sourceFile);
            
            string macro = "Sheet1.SendEmailToUser";
            try
            {
                ExcelApp.Run(macro);
                Console.WriteLine("Macro: " + macro + " exceuted successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to Run Macro: " + macro + " Exception: " + ex.Message);
            }
            
            ExcelWorkBook.Close(false);
            ExcelApp.Quit();
            if (ExcelWorkBook != null) { System.Runtime.InteropServices.Marshal.ReleaseComObject(ExcelWorkBook); }
            if (ExcelApp != null) { System.Runtime.InteropServices.Marshal.ReleaseComObject(ExcelApp); }
        }
