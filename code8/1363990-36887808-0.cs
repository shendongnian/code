    try
    {
                SqlDataAdapter adapt = new SqlDataAdapter("Table1_Select", ConnectionString);
                adapt.SelectCommand.Parameters.AddWithValue("@yourparameters", param);
    
                adapt.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                adapt.Fill(dt);
                adapt.Dispose();
                adapt = null;
           
                return dt;
    }
    catch(Exception ex)
    {
    throw ex
    }
