    public class ExcelTable
    {
        public ExcelTable() 
        {
            // create new excel-application and so on..
            //initialize xlWorkbook and xlWorksheet
            Output = new ExcelOutput(xlWorkbook, xlWorksheet);
        }
        public ExcelOutput Output;
        private Workbook xlWorkbook;
        private Worksheet xlWorksheet;
        public class ExcelOutput
        {
            private Workbook xlWorkbook;  
            private Worksheet xlWorksheet;
            public ExcelOutput(Workbook xl_workbook, Worksheet xl_worksheet)
            {
                xlWorkbook = xl_workbook;
                xlWorksheet = xl_worksheet;
            }
            public void SaveAs()
            {
                // self explaining
            }
            public void Show()
            {
                // self explaining
            }
            public void Print()
            {
                
            }
            //....
        }
    }
