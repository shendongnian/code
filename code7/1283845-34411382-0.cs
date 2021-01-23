            //here's some class I used
            public class Movie
            {
                public int MovieID { get; set; }
                public string MovieName { get; set; }
    
                public System.Data.DataTable MovieListDataTable()
                {
                    System.Data.DataTable dataTable = new System.Data.DataTable();
                    dataTable.Columns.Add("MovieID", typeof(int));
                    dataTable.Columns.Add("MovieName", typeof(string));
    
                    for (int x = 0; x <= 100000; x++)
                    {
                        dataTable.Rows.Add(new object[] { x, "Star Wars " + x.ToString() });
                    }
    
                    return dataTable;
                }
    
                public String GetExcelColumnName(int columnIndex)
                {
                    if (columnIndex < 0)
                    {
                        throw new ArgumentOutOfRangeException("columnIndex: " + columnIndex);
                    }
                    Stack<char> stack = new Stack<char>();
                    while (columnIndex >= 0)
                    {
                        stack.Push((char)('A' + (columnIndex % 26)));
                        columnIndex = (columnIndex / 26) - 1;
                    }
                    return new String(stack.ToArray());
                }
            }
            
            // then inside the MAIN
            static void Main(string[] args)
            {
                Application myExcelApp = new Application();
                _Worksheet myExcelWorkSheet; //= new _Worksheet();
    
                Movie movie = new Movie();
                
                //ensure that you have a Book1.xlsx the same path as this program.
                string ExcelFilePath = AppDomain.CurrentDomain.BaseDirectory + "Book1.xlsx";
                string letterStart = "";
                string letterEnd = "";
    
                int row = 0, col = 0;
    
                var toPrint = movie.MovieListDataTable();
                row = toPrint.Rows.Count;
                col = toPrint.Columns.Count;
    
                letterStart = movie.GetExcelColumnName(0);
                letterEnd = movie.GetExcelColumnName(col - 1);
    
                Workbook myExcelWorkBook = myExcelApp.Workbooks.Open(ExcelFilePath);
                myExcelWorkSheet = myExcelWorkBook.Worksheets[1];
    
                var dataBulk = new object[row, movie.GetType().GetProperties().Count()];
    
                for (int printx = 0; printx < row; printx++)
                {
                    for (int printy = 0; printy < col; printy++)
                    {
                        dataBulk[printx, printy] = toPrint.Rows[printx][printy].ToString();
                    }
                }
                
                //print start cell range
                Range startCellRange = myExcelWorkSheet.Range[letterStart + 1.ToString(), letterStart + 1.ToString()];
                //print end cell range
                Range endCellRange = myExcelWorkSheet.Range[letterEnd + row.ToString(), letterEnd + row.ToString().ToString()];
                //full write cell range
                Range writeRange = myExcelWorkSheet.Range[startCellRange, endCellRange];
    
                //data to print within range
                writeRange.Value2 = dataBulk;
    
                myExcelWorkBook.Save();
                myExcelWorkBook.Close();
    
                Marshal.ReleaseComObject(myExcelWorkBook);
                Marshal.ReleaseComObject(myExcelWorkSheet);
                Marshal.ReleaseComObject(myExcelApp);
            }
