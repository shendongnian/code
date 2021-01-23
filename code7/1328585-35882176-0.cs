    DataTable timeSeriesDataDT = new DataTable();
    using (OleDbConnection AccessConnDT = new OleDbConnection(strAccessConn))
    {
        using (OleDbCommand cmdGetDT = new OleDbCommand(sqlSELECT, AccessConnDT))
        {
            AccessConnDT.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmdGetDT);
            adapter.Fill(timeSeriesDataDT);
        }
    }
