                SqlConnection sqlConnection = new SqlConnection(sqlConnectionString);
            sqlConnection.Open();
            SqlBulkCopy bulkCopy = new SqlBulkCopy(sqlConnection);
            bulkCopy.DestinationTableName = _stagingTableName;
            foreach (DataColumn col in _jobRecDT.Columns)
            {
                //System.Windows.Forms.MessageBox.Show(col.ColumnName);
                bulkCopy.ColumnMappings.Add(col.ColumnName, col.ColumnName);
            }
            bulkCopy.WriteToServer(_jobRecDT);
            sqlConnection.Close();
