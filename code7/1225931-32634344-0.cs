    using System.Data.SqlClient;
    using (SqlConnection conn = new SqlConnection("connectionString"))
    {
        SqlCommand cmd = conn.CreateCommand();
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.CommandText = "dbo.p_Role_dfn_createNew";
        
        // add other parameters...
        cmd.Parameters.Add(new SqlParameter("@RoleID", SqlDbType.BigInt))
                .Direction = ParameterDirection.Output;
        cmd.ExecuteNonQuery();
        
        returnValue = (long)cmd.Parameters["@RoleID"].Value;
    }
