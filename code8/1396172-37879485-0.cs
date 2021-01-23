    private void ExcelExport(DataTable table)
            {
                using (ExcelPackage packge = new ExcelPackage())
                {
                    //Create the worksheet
                    ExcelWorksheet ws = packge.Workbook.Worksheets.Add("Demo");
    
                    //Load the datatable into the sheet, starting from cell A1. Print the column names on row 1
                    ws.Cells["A1"].LoadFromDataTable(table, true);
    
                    //Format the header for column 1-3
                    using (ExcelRange range = ws.Cells["A1:C1"])
                    {
                        range.Style.Font.Bold = true;
                        range.Style.Fill.PatternType = ExcelFillStyle.Solid;                      //Set Pattern for the background to Solid
                        range.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(79, 129, 189)); //Set color to dark blue
                        range.Style.Font.Color.SetColor(Color.White);
                    }
    
                   //Example how to Format Column 1 as numeric 
                    using (ExcelRange col = ws.Cells[2, 1, 2 + table.Rows.Count, 1])
                    {
                        col.Style.Numberformat.Format = "#,##0.00";
                        col.Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    }
    
                    //Write it back to the client
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;  filename=ExcelExport.xlsx");
                    Response.BinaryWrite(packge.GetAsByteArray());
                }
            }
