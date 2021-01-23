        Microsoft.Office.Interop.Excel.Application xlexcel;
        Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
        Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet1;// defines sheet1
        Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet2;// defines sheet2
        Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet3;// defines sheet3
        object misValue = System.Reflection.Missing.Value;
        xlWorkBook = xlexcel.Workbooks.Add(misValue);
        for (int i = 0; i < 2; i++) // here we add the rest of sheet into the excel
        {
           xlexcel.Sheets.Add(After: xlexcel.Sheets[xlexcel.Sheets.Count]);
        }       
       xlWorkSheet1 = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1); //setting the first sheet equal to first sheet in excel
       xlWorkSheet2 = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(2);//setting the 2nd sheet equal to first sheet in excel
       xlWorkSheet3 =  (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(3);
        
    //here we add the data to the sheet from datagridview    
        for (int j = 0; j <= dataGridView1.ColumnCount - 1; j++)
                {
                    xlWorkSheet1.Cells[1, j + 1] = dataGridView1.Columns[j].HeaderText;
                }
            for (int i = 0; i <= dataGridView1.RowCount - 1; i++)
                {
                 for (int j = 0; j <= dataGridView1.ColumnCount - 1; j++)
                       {
                           DataGridViewCell cell = dataGridView1[j, i];
                           xlWorkSheet1.Cells[i + 2, j + 1] = cell.Value;
                       }
                }                      
              xlWorkSheet1.Name = "put name here";
              xlWorkSheet1.Columns.AutoFit();
                    
            for (int j = 0; j <= dataGridView2.ColumnCount - 1; j++)
                {
                    xlWorkSheet2.Cells[1, j + 1] = dataGridView2.Columns[j].HeaderText;
                }
            for (int i = 0; i <= dataGridView2.RowCount - 1; i++)
                {
                 for (int j = 0; j <= dataGridView2.ColumnCount - 1; j++)
                       {
                           DataGridViewCell cell = dataGridView2[j, i];
                           xlWorkSheet2.Cells[i + 2, j + 1] = cell.Value;
                       }
                }                      
              xlWorkSheet2.Name = "put name here";
              xlWorkSheet2.Columns.AutoFit();   
               
            for (int j = 0; j <= dataGridView3.ColumnCount - 1; j++)
                {
                    xlWorkSheet3.Cells[1, j + 1] = dataGridView3.Columns[j].HeaderText;
                }
            for (int i = 0; i <= dataGridView3.RowCount - 1; i++)
                {
                 for (int j = 0; j <= dataGridView3.ColumnCount - 1; j++)
                       {
                           DataGridViewCell cell = dataGridView3[j, i];
                           xlWorkSheet3.Cells[i + 2, j + 1] = cell.Value;
                       }
                }                      
              xlWorkSheet3.Name = "put name here";
              xlWorkSheet3.Columns.AutoFit();  
    xlWorkBook.SaveAs("put path here", Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                        xlWorkBook.Close(true, misValue, misValue);
                        xlexcel.Quit();
