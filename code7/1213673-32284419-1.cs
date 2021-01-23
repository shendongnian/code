    private DataTable ExecuteReader(string sqlcmd)
    {
        DataTable table = new DataTable();
        using (SqlConnection con = new SqlConnection(objCon.getConnectionString()))
        {
            using (SqlDataAdapter da = new SqlDataAdapter(sqlcmd, con))
            {
                con.Open();
                da.Fill(table);
            }
        }
        return table;
        
    }
