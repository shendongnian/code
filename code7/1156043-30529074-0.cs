    xlWorkBook = xlApp.Workbooks.Open(@"C:\Users\bla\blas\users.xlsx", 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
    xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);                
    Range range1 = worksheet1.Cells[1, 1];
    Range range2 = worksheet1.Cells[3, 3];
    Range range = worksheet1.get_Range(range1, range2);
    object[,] valArray = range.Value2 as object[,];
    int xCount = valArray.GetLength(0);
    int yCount = valArray.GetLength(1);
    for (int i = 1; i <= xCount; i++)
    {
        for (int j = 1; j <= yCount; j++)
        {
            object currentValue = valArray[i, j];
            if (currentValue != null)
            {
                Console.WriteLine(currentValue.ToString());
            }
        }
    }
