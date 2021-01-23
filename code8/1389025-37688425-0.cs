    private static SqlDataReader reader;
    private static SqlConnection dbconn = new SqlConnection(SQLServer.Settings.ConnectionString);
    private void GetNextRows(int numRows)
        {
            if (dbconn.State != ConnectionState.Open)
                OpenConnection();
            // Iterate columns one by one for the specified limit.
            int rowCnt = 0;
            while (rowCnt < numRows)
            {
                while (reader.Read())
                {
                        object[] row = new object[reader.FieldCount];
                        reader.GetValues(row);
                        resultsTable.LoadDataRow(row, LoadOption.PreserveChanges);
                        rowCnt++;
                        sessionRowPosition++;
                        break;
                }
            }
        }
