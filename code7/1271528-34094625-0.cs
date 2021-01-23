        //select first row 
        Microsoft.Office.Interop.Excel.Range firstRow = Worksheet.UsedRange.Rows[1];
        //merge the cells of the first row
        firstRow.Merge();
        //set the first rows backcolor to gray
        firstRow.Interior.Color = System.Drawing.Color.Gray;enter code here
        //set the textcolor of the first row to white
        firstRow.Font.Color = System.Drawing.Color.White;
        //set the text to the center of the merged cells
        firstRow.HorizontalAlignment = XlHAlign.xlHAlignCenter;
        firstRow.VerticalAlignment = XlVAlign.xlVAlignCenter;
