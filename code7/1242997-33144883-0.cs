    DataSet ds = new DataSet();
    using (OleDbConnection con = new OleDbConnection(MDBConnection.ConnectionString))
    {
        con.Open();
        using (OleDbCommand cmd = new OleDbCommand("SELECT Column FROM Table1", con))
        {
            using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
            {
                da.Fill(ds);
            }
        }
                
        using (OleDbCommand cmd = new OleDbCommand("SELECT AnotherColumn FROM Table2", con))
        {
            using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
            {
                da.Fill(ds);
            }
        }
    }
    return ds;
