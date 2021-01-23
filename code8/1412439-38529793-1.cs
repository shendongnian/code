    public bool compareFiles(string filePath1, string filePath2)
        {
            bool result = false;
            Excel.Application excel = new Excel.Application();
            //Open files to compare
            Excel.Workbook workbook1 = excel.Workbooks.Open(filePath1);
            Excel.Workbook workbook2 = excel.Workbooks.Open(filePath2);
            //Open sheets to grab values from
            Excel.Worksheet worksheet1 = (Excel.Worksheet)workbook1.Sheets[1];
            Excel.Worksheet worksheet2 = (Excel.Worksheet)workbook2.Sheets[1];
            //Get the used range of cells
            Excel.Range range = worksheet2.UsedRange;
            int maxColumns = range.Columns.Count;
            int maxRows = range.Rows.Count;
            //Check that each cell matches
            for (int i = 1; i <= maxColumns; i++)
            {
                for (int j = 1; j <= maxRows; j++)
                {
                    if (worksheet1.Cells[j, i].Value == worksheet2.Cells[j, i].Value)
                    {
                        result = true;
                    }
                    else
                        result = false;
                }
            }
            //Close the workbooks
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Marshal.ReleaseComObject(range);
            Marshal.ReleaseComObject(worksheet1);
            Marshal.ReleaseComObject(worksheet2);
            workbook1.Close();
            workbook2.Close();
            excel.Quit();
            Marshal.ReleaseComObject(excel);
            //Tell us if it is true or false
            return result;
        }
