    private DataTable ExecuteReader(string sqlcmd)
    {
        DataTable table = new DataTable();
        using (var con = new SqlConnection(objCon.getConnectionString()))
        {
            using (var da = new SqlDataAdapter(sqlcmd, con))
            {
                con.Open();
                da.Fill(table);
            }
        }
        return table;
        
    }
