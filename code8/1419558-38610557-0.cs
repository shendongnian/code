     public void CreateExcel(DataTable dt, string path)
        {
    
            try
            {
                if (File.Exists(path))
                    File.Delete(path);
    
                FileInfo newFile = new FileInfo(path);
                using (ExcelPackage pck = new ExcelPackage(newFile))
                {
                    //Create the worksheet
                    ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Query Result");
    
                    //Load the datatable into the sheet, starting from cell A1. Print the column names on row 1
                    //ws.Cells["A1"].LoadFromDataTable(dt, true);
                    //ws.Cells["A1"].AutoFitColumns();
    
                    int columnNumber = 0;
                    foreach (DataColumn dc in dt.Columns)
                    {
                        columnNumber++;
                        ws.Cells[1, columnNumber].Value = dc.ColumnName;
                    }
    
                    //Adding data of each row.
                    int rowNumber = 0;
                    foreach (DataRow rw in dt.Rows)
                    {
                        rowNumber++;
    
                        columnNumber = 0;
                        foreach (DataColumn dc in dt.Columns)
                        {
                            columnNumber++;
                            //Formating columns based on data types
                            if (rw[dc.ColumnName].GetType().ToString() == "System.Int32" || rw[dc.ColumnName].GetType().ToString() == "System.Double")
                                ws.Cells[rowNumber + 1, columnNumber].Style.Numberformat.Format = "0";
                            else if (rw[dc.ColumnName].GetType().ToString() == "System.DateTime")
                                ws.Cells[rowNumber + 1, columnNumber].Style.Numberformat.Format = "yyyy-mm-dd hh:mm:ss";
                            else if (rw[dc.ColumnName].GetType().ToString() == "System.Decimal")
                                ws.Cells[rowNumber + 1, columnNumber].Style.Numberformat.Format = "0.00";
    
                            ws.Cells[rowNumber + 1, columnNumber].Value = rw[dc.ColumnName];
                        }
                    }
    
    
                    //Format the header for columns
                    using (ExcelRange rng = ws.Cells["A1:Z1"])
                    {
                        rng.Style.Font.Bold = true;
                       
                    }
    
                    //Format Cells 
                    using (ExcelRange col = ws.Cells[2, 1, dt.Rows.Count + 1, dt.Columns.Count + 1])
                    {
                        col.Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        col.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        col.AutoFitColumns();
                    }
    
                    //Saving the excel sheet
                    pck.Save();
                }
    
            }
            catch (Exception ex)
            {
            }
    
          
    
        }
