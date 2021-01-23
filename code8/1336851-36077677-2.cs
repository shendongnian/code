    using Excel = Microsoft.Office.Interop.Excel;
    
            Excel.Application app = new Excel.Application();
            Excel.Workbook wb = app.Workbooks.Open("path to a workbook");
            Excel.Worksheet sheet = (Excel.Worksheet)wb.Sheets[1];
            int lastrow = sheet.UsedRange.Rows.Count;
            int lastcol = sheet.UsedRange.Rows.Count;
            Excel.Range c1;
            Excel.Range c2;
            for (int i = 1; i <= lastrow; i++)
            {
                c1 = (Excel.Range)sheet.Cells[i, 1];
                c2 = (Excel.Range)sheet.Cells[i, lastcol];
                Excel.Range range = sheet.Range[c1, c2];
                foreach(Object o in (System.Array)range.Value)
                {
                    if (o != null)
                    {
                        Console.Write(o.ToString());
                    }
                }
                Console.WriteLine();
            }
            Console.ReadLine();
   
    
