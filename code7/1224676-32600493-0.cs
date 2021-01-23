    using System.Data.SqlClient;
    using (SqlConnection conn = new SqlConnection("connectionString"))
    {
        SqlCommand cmd = conn.CreateCommand();
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.CommandText = "StoredProcedureName";
        cmd.ExecuteNonQuery();
    }
