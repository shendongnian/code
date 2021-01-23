    namespace TestExcelAddIn
    {
        public partial class ExcelTest
        {
            private StringGetter myAddIn;
    
            protected override object RequestComAddInAutomationService()
            {
                if (myAddIn == null)
                    myAddIn = new StringGetter();
    
                return myAddIn;
            }
    
            private void ThisAddIn_Startup(object sender, System.EventArgs e)
            {
            }
    
            private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
            {
            }
    
            #region VSTO generated code
            #endregion
        }
    }
