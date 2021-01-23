        private void button1_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application xlexcel;
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlexcel = new Excel.Application();
            xlexcel.Visible=true ;
            xlWorkBook = xlexcel.Workbooks.Open(
                        "C:\\Users\\Siddharth\\Desktop\\Delete Later\\Sample.xlsx", 
                        0, true, 5, "", "", true, 
                        Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, 
                        "\t", false, false, 0, true, 1, 0);
            // Set Sheet 1 as the sheet you want to work with
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            String cellvalue = xlWorkSheet.Cells[1, 1].Value.ToString("MM/dd/yyyy", 
                               CultureInfo.InvariantCulture);
            MessageBox.Show(cellvalue);
            //
            //~~> Rest of the code
            //
        }
