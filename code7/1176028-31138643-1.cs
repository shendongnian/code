    using OfficeOpenXml;
    using OfficeOpenXml.Style;
    using System;
    using System.IO;
    using System.Drawing;
    
    namespace EPPlus_AutoSave_Excel_Export
    {
        class Sample_Auto_Save
        {
            int Rows;
            int nRowsWritten = 0;
            bool bAppendData = false;
            ExcelWorksheet ws;
            DirectoryInfo outputDir;
    
            
            public Sample_Auto_Save(DirectoryInfo outputDir, int Rows)
            {
                this.Rows = Rows;
                this.outputDir = outputDir;
            }
    
            public void ExportWithAutoSave()
            {
    
                FileInfo newFile = new FileInfo(outputDir.FullName + @"\Auto_Save_Export.xlsx");
                if (newFile.Exists)
                {
                    newFile.Delete();  // ensures we create a new workbook
                    newFile = new FileInfo(outputDir.FullName + @"\Auto_Save_Export.xlsx");
                }
    
                Console.WriteLine("{0:HH.mm.ss}\tStarting...", DateTime.Now);
                while (nRowsWritten < Rows)
                {
                    if (bAppendData == false)
                    {
                        using (ExcelPackage package = new ExcelPackage())
                        {
                            
                            //Load the sheet with one string column, one date column and a few random numbers
                            ws = package.Workbook.Worksheets.Add("Performance Test");
                            InsertRows();
                            bAppendData = true;
                            AutoSave(newFile, package);
                        }
                    }
                    else
                    {
                        using (ExcelPackage package = new ExcelPackage(newFile))
                        {
                            Console.WriteLine("{0:HH.mm.ss}\tOpening existing file again!...", DateTime.Now);
                            ws = package.Workbook.Worksheets["Performance Test"];
    
                            InsertRows();
    
                            AutoSave(newFile, package);
                        }
                    }       
                }
                Console.WriteLine("{0:HH.mm.ss}\tDone!!", DateTime.Now);           
            }
    
            private void AutoSave(FileInfo newFile, ExcelPackage package)
            {
                ws.Select("C2");
                Console.WriteLine("{0:HH.mm.ss}\tAuto-Saving...", DateTime.Now);
                package.Compression = CompressionLevel.BestSpeed;
                package.SaveAs(newFile);
                bAppendData = true;
            }
    
            private void InsertRows()
            {
    
                //Format all cells
                ExcelRange cols = ws.Cells["A:XFD"];
                cols.Style.Fill.PatternType = ExcelFillStyle.Solid;
                cols.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
    
                var rnd = new Random();
                int startRow;
                if (ws.Dimension == null)
                    startRow = 0;
                else
                    startRow = ws.Dimension.End.Row;
                for (int row = startRow + 1; row <= Rows; row++, nRowsWritten++)
                {
                    ws.SetValue(row, 1, row);                               //The SetValue method is a little bit faster than using the Value property
                    ws.SetValue(row, 2, string.Format("Row {0}", row));
                    ws.SetValue(row, 3, DateTime.Now.ToShortTimeString());
                    ws.SetValue(row, 4, rnd.NextDouble() * 10000);
                  
    
                    if (row % (Rows/5) == 0)
                    {
                        Console.WriteLine("{0:HH.mm.ss}\tWritten {1} records!...", DateTime.Now, row);
                        nRowsWritten++;
                        return;
                    }
                }
            }
        }
    }
----------
