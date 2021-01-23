    if (FileUploadControl.HasFile)
            {
                
                
                try
                {
                    if (FileUploadControl.PostedFile.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" || FileUploadControl.PostedFile.ContentType == "application/vnd.ms-excel")
                    {
                        if (FileUploadControl.PostedFile.ContentLength >= 0)
                        {
                            string filename = Path.GetFileNameWithoutExtension(FileUploadControl.FileName);
                            string fileExt = Path.GetExtension(FileUploadControl.FileName);
    
                            FileUploadControl.SaveAs(Server.MapPath("~/DownloadedExcelFilesOp4/myfile" + fileExt));
                            if (FileUploadControl.PostedFile.ContentLength == 0)
                            {
                                lblMsg.Text = fun.UploadStatus;
                                lblMsg.ForeColor = Color.Green;
                            }
                            else
                                lblMsg.Text = fun.UploadStatus;
                            lblMsg.ForeColor = Color.Green;
                            string excelConnectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HRD=YES;IMEX=1'", Server.MapPath(@"~\DownloadedExcelFilesOp4\myfile" + fileExt));// + "\\" + FileUploadControl.PostedFile.FileName.ToString());
                            using (OleDbConnection connection = new OleDbConnection(excelConnectionString))
                            {
                                OleDbCommand command = new OleDbCommand(("Select [Customer] ,[InvoiceDate] , [InvoiceNo] , [CustomerPo],[SoLine] ,[VendorName] ,[Category] ,[Item] ,[PickQty] ,[Price] ,[PriceExtentio]  FROM [Sheet1$]"), connection);
                                connection.Open();
                                using (DbDataReader dr = command.ExecuteReader())
                                {
                                    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(ConfigurationManager.ConnectionStrings["ConString"].ConnectionString))
                                    {
                                        bulkCopy.DestinationTableName = "TempExamQuation4Master";
                                        bulkCopy.ColumnMappings.Add("Customer", "Customer");
                                        bulkCopy.ColumnMappings.Add("InvoiceDate", "InvoiceDate");
                                        bulkCopy.ColumnMappings.Add("InvoiceNo", "InvoiceNo");
                                        bulkCopy.ColumnMappings.Add("CustomerPo", "CustomerPo");
                                        bulkCopy.ColumnMappings.Add("SoLine", "SoLine");
                                        bulkCopy.ColumnMappings.Add("VendorName", "VendorName");
                                        bulkCopy.ColumnMappings.Add("Categor", "Categor");
                                        bulkCopy.ColumnMappings.Add("Item", "Item");
                                        bulkCopy.ColumnMappings.Add("PickQty", "PickQty");
                                        bulkCopy.ColumnMappings.Add("Price", "Price");
                                        bulkCopy.ColumnMappings.Add("PriceExtentio", "PriceExtentio");
                                        
                                        bulkCopy.WriteToServer(dr);
                                    }
                                }
                            }
