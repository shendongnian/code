    public DataSet GetFactureInfo()
    {
        DbConnection conn = null;
        DataSet dataSet = null;
        
        try
        {
            conn = new OleDbConnection(
                "Provider=Microsoft.Jet.OLEDB.4.0; " + 
                "Data Source=" + Server.MapPath("MyDataFolder/MyAccessDb.mdb"));
            conn.Open();
            DbDataAdapter dataAdapter = 
                new OleDbDataAdapter("select facture, count(l.le_ville) as nbre
                    from table
                    group by l.le_ville", conn);
            dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            return dataSet;
        }
        finally
        {
            if (dataAdapter != null)  dataAdapter.Dispose();
            if (conn != null)  conn.Dispose();
        }
        return null;
    }
