            static void Main(string[] args)
            {
                ExcelPackage ep = new ExcelPackage(new FileInfo(@"d:\temp\EPTest.xlsx"));
                ExcelWorksheet ws = ep.Workbook.Worksheets.First();
                //Get all the cells with text "A" in column "A"
                var acells = from cell in ws.Cells["A:A"] where cell.Text.Equals("A") select cell;
                //To insert row after the last identified "A" increment the row number by 1
                ws.InsertRow(acells.Last().End.Row + 1,1);
                ep.Save();
            }
