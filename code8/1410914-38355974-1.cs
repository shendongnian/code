    try
    {
        using (SqlConnection conn = new SqlConnection(cCon.getConn()))
        {
            using (SqlCommand cmd = conn.CreateCommand())
            {
                conn.Open();
    
                cmd.CommandText = "sp_SaveR";                                           
                cmd.CommandType = CommandType.StoredProcedure;
    
                cmd.Parameters.Add(new SqlParameter("@fname", fName));
                cmd.Parameters.Add(new SqlParameter("@lname", lName));
                cmd.Parameters.Add(new SqlParameter("@mname", mName));                       
                cmd.Parameters.Add(new SqlParameter("@sigDate", sigDate));
                cmd.Parameters.Add("@NewId", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                int userId = Convert.ToInt32(cmd.Parameters["@NewId"].Value);
            }
        }
    }
    catch (Exception ex)
    {
        throw(ex);
    }
