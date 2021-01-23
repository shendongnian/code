    string connectionString = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
    string insertStoredProcName = "dbo.InsertNode";
    
    using (SqlConnection conn = new SqlConnection(connectionString))
    using (SqlCommand cmd = new SqlCommand(insertStoredProcName, conn))
    {
        cmd.CommandType = CommandType.StoredProcedure;
        -- set up paramters - DO NOT USE AddWithValue !!        
        cmd.Parameters.Add("@FName", SqlDbType.VarChar, 100).Value = FName;
        cmd.Parameters.Add("@Lname", SqlDbType.VarChar, 100).Value = LName;
        cmd.Parameters.Add("@CDesc", SqlDbType.VarChar, 100).Value = cDesc;
        cmd.Parameters.Add("@ParentID", SqlDbType.Int).Value = pid;
        conn.Open();
        
        using(SqlDataReader rdr = cmd.ExecuteReader())
        {
            while (rdr.Read())
            {
                -- read all returned values - if you only ever insert
                -- one row at a time, there will only be one value to read
               int insertedId = rdr.GetInt32(0);
            }
        
            rdr.Close();
        }
        
        conn.Close();
    }
