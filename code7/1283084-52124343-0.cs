        private Excel.Workbook GenerateExcel()
        {
            string excelFileName = HttpContext.Current.Server.MapPath("~/App_Data/TestFile.xlsx");
            Excel.Application excel = null;
            Excel.Workbook excelworkBook = null;
            try
            {
                excel = new Excel.Application();
                excel.Visible = false;
                excel.DisplayAlerts = false;
                //create two sheets AAA & BBB
                excelworkBook = excel.Workbooks.Add();
                Excel.Worksheet excelSheet1 = (Excel.Worksheet)excelworkBook.ActiveSheet;
                excelSheet1.Name = "AAA";
                Excel.Worksheet excelSheet2 = (Excel.Worksheet)excelworkBook.Worksheets.Add();
                excelSheet2.Name = "BBB";
                DataTable dataTable = GetTable();
                // now we resize the columns
                Excel.Range excelCellrange1 = excelSheet1.Range[excelSheet1.Cells[1, 1], excelSheet1.Cells[dataTable.Rows.Count, dataTable.Columns.Count]];
                excelCellrange1.EntireColumn.AutoFit();
                //Now fill excelSheet1 up with data
                int row = 1;
                int col = 1;
                foreach (DataRow r in dataTable.Rows)
                {
                    for (int j = 0; j < dataTable.Columns.Count; j++ )
                    {
                        excelSheet1.Cells[row, col] = r[j];
                        col++;
                    }
                    row++;
                }
                //Now fill excelSheet2
                row = 1;
                col = 1;
                foreach (DataRow r in dataTable.Rows)
                {
                    for (int j = 0; j < dataTable.Columns.Count; j++)
                    {
                        excelSheet2.Cells[row, col] = r[j];
                        col++;
                    }
                    row++;
                }
            }
            catch (System.Exception ex)
            {
            }
            finally
            {
                excelworkBook.SaveAs(excelFileName);
                excel.Quit();
                excel = null;
                excelworkBook = null;
                FileInfo file = new FileInfo(excelFileName);
                if (file.Exists)
                {
                    Response.Clear();
                    Response.AppendHeader("Content-Disposition", "attachment; filename=" + file.Name);
                    Response.AddHeader("Content-Length", file.Length.ToString());
                    Response.TransmitFile(file.FullName);
                    Response.Flush();
                    Response.End();
                }
            }
            return excelworkBook;
        }
