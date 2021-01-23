    Excel.Application xlApp = new Excel.Application();
    //Points to the excel path
    Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(@"E:\USERS\MyWorkbook.xlsx");    
    //Sheets[1] = First worksheet, modify this according to your need
    Excel.Worksheet xlWorksheet = xlWorkbook.Sheets[1];    
    //UsedRange means the range of cells that has contents (are being used).
    Excel.Range xlRange = xlWorksheet.UsedRange;
    int rowCount = xlRange.Rows.Count;
    int colCount = xlRange.Columns.Count;
    for (int i = 1; i <= rowCount; i++)
        {
            for (int j = 1; j <= colCount; j++)
            {
                var cellContent = xlWorksheet.Cells[i, j].Value;
                //To prevent exceptions due to null reference         
                if (cellContent != null)
                {
                    Console.WriteLine(cellContent.ToString());
                }                  
            }
        }              
    
