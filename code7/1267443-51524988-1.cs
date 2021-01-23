    /// <summary>
        /// Export button click event
        /// </summary>
        /// <returns>Return the excel file with multiple sheets</returns>
        public ActionResult ExportToExcel()
        {
            var sheetNames = new List<string>() { "sheetName1", "sheetName2" };
            string fileName = "Example.xlsx";
            DataSet ds = GetDataSetExportToExcel();
            XLWorkbook wbook = new XLWorkbook();
            for (int k = 0; k < ds.Tables.Count; k++)
            {
                DataTable dt = ds.Tables[k];
                IXLWorksheet Sheet = wbook.Worksheets.Add(sheetNames[k]);
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    Sheet.Cell(1, (i + 1)).Value = dt.Columns[i].ColumnName;
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        Sheet.Cell((i + 2), (j + 1)).Value = dt.Rows[i][j].ToString();
                    }
                }
            }
            Stream spreadsheetStream = new MemoryStream();
            wbook.SaveAs(spreadsheetStream);
            spreadsheetStream.Position = 0;
            return new FileStreamResult(spreadsheetStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet") { FileDownloadName = fileName };
        }
