            string UploadedFilePath = FullPathOfExcelOnTheServer;
            string ExcelConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + UploadedFilePath + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=1;FMT=Delimited\"";
            using (OleDbConnection oledbConnExcel = new OleDbConnection(ExcelConn))
            {
                oledbConnExcel.Open();
                using (OleDbDataAdapter oledbAdapterExcel = new OleDbDataAdapter("SELECT * from [" + SheetName + "$]", oledbConnExcel))
                {
                    using (DataTable dtblSheetData = new DataTable())
                    {
                        try
                        {
                            oledbAdapterExcel.Fill(dtblSheetData);
                        }
                        catch (Exception lexQuery)
                        {
                        }
                    }
                }
                oledbConnExcel.Close();
            }
