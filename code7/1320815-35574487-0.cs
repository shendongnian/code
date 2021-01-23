    using Excel = Microsoft.Office.Interop.Excel;
    using System.Reflection;
    using System.IO;
    
            //Print using Ofice InterOp
            Excel.Application excel = new Excel.Application();
    
            var workbook = (Excel._Workbook)(excel.Workbooks.Add(Missing.Value));
    
            for (var i = 0; i < dataset.Tables.Count; i++)
            {
    
                    if (workbook.Sheets.Count <= i)
                    {
                        workbook.Sheets.Add(Type.Missing, Type.Missing, Type.Missing,
                                            Type.Missing);
                    }
    
                    //NOTE: Excel numbering goes from 1 to n
                    var currentSheet = (Excel._Worksheet)workbook.Sheets[i + 1]; 
    
                    for (var y = 0; y < dataset.Tables[i].Rows.Count; y++)
                    {
                        for (var x = 0; x < dataset.Tables[i].Rows[y].ItemArray.Count(); x++)
                        {
                            currentSheet.Cells[y+1, x+1] = dataset.Tables[i].Rows[y].ItemArray[x];
                        }
                    }
            }
    
            string outfile = @"C:\excel.xlsx";
    
            workbook.SaveAs( outfile, Type.Missing, Type.Missing, Type.Missing,
                            Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange,
                            Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                            Type.Missing);
    
            workbook.Close();
            excel.Quit();
