     if (ExlSheet.HasFile)
            {
                string fileName = Path.GetFileName(ExlSheet.PostedFile.FileName);
                string fileExtension = Path.GetExtension(ExlSheet.PostedFile.FileName);
                string fileLocation = Server.MapPath("~/App_Data/" + fileName);
                ExlSheet.SaveAs(fileLocation);
                ExcelQueryFactory excelFile = new ExcelQueryFactory(fileLocation);
    
                var data = from a in excelFile.Worksheet("Sheet1") select a;
    
    
                var columnNames = excelFile.GetColumnNames("Sheet1");
                DataTable dtExcelRecords = new DataTable();
                foreach (var columnName in columnNames)
                {
                    dtExcelRecords.Columns.Add(columnName);
                }
                foreach (var row in data)
                {
                    DataRow dr = dtExcelRecords.NewRow();
                    foreach (var columnName in columnNames)
                    {
                        dr[columnName] = row[columnName];
                    }
                    dtExcelRecords.Rows.Add(dr);
                }
                gv.DataSource = dtExcelRecords;
                gv.DataBind();
            }
