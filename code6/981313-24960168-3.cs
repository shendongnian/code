           // SQL Server Connection String
           string sqlConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + path2 + ";Integrated Security=True";
           // Bulk Copy to SQL Server
           using (SqlBulkCopy bulkCopy = new SqlBulkCopy(sqlConnectionString))
           {
              bulkCopy.DestinationTableName = "[dbo].[Table]";
              bulkCopy.WriteToServer(OleDs.Tables[0]);
              MessageBox.Show("Data Exoprted To Sql Server Succefully");
           }
