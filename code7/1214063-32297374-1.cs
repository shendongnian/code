    private void intrebarea(int ni)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from tbl Where Id = @Id", con);
        cmd.Parameters.Add(new SqlParameter("@Id", System.Data.SqlDbType.Int)));
        cmd.Parameters["@Id"].Value = ni;
        SqlDataReader rdr = cmd.ExecuteReader();
        rdr.Read();
    }
