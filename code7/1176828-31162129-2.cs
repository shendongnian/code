    public string[] GetExcelSheets(string filename)
            {
                String[] excelSheets = null;
                StorageCredentials creds = new StorageCredentials("<accountname>", "<key>");
                CloudStorageAccount account = new CloudStorageAccount(creds, useHttps: true);
                CloudBlobClient blobClient = account.CreateCloudBlobClient();
                CloudBlobContainer blobContainer = blobClient.GetContainerReference("documents");
                blobContainer.CreateIfNotExists();
               blobContainer.SetPermissions(new BlobContainerPermissions
    {  PublicAccess = BlobContainerPublicAccessType.Blob
                });
                CloudBlockBlob blob1 = blobContainer.GetBlockBlobReference(filename);
                try
                {
                    using (var stream = blob1.OpenRead())
                    {
                        OleDbConnection connection = new OleDbConnection();
                        var localPath = @"https://xxyyyyyyyyyyy.blob.core.windows.net/";
                        var fileName = @"C:\xxx" + @"\" + "9370.XLS";
                        var fullPathToFile = System.IO.Path.Combine(localPath, fileName);
                        string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + fileName + "';Extended Properties=Excel 8.0";
                       OleDbConnection oledbConn = new OleDbConnection(connString);
                        DataTable dt = new DataTable();
                        if (oledbConn.State == ConnectionState.Closed) oledbConn.Open();
                        // Get the data table containg the schema guid.
                        dt = oledbConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                        oledbConn.Close();
                        if (dt == null) return null;
                        excelSheets = new String[dt.Rows.Count];
                        int i = 0;
                        // Add the sheet name to the string array.
                        foreach (DataRow row in dt.Rows)
                        {
                            excel Sheets[i] = row["TABLE_NAME"].ToString();
                            i++;
                        }
                    }
                }
                catch (Exception ex)
                {
                    HTTP Context.Current.Res`enter code here`ponse.Write(ex.Message);
                }
                return excel Sheets; }
    this is the code i used to read the excel file but oledb data-source path is incorrect...can u suggest what path i should use to read the excel file in azure blob container 
