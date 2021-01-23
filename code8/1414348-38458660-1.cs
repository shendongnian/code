    cmd.Parameters.Add("@rc", SqlDbType.Int).Direction = ParameterDirection.Output;
    try
    {
        if (cmd.Connection.State == ConnectionState.Closed)
        {
            cmd.Connection.Open();
        }
        cmd.ExecuteNonQuery();
        result = Convert.ToBoolean(cmd.Parameters["@rc"].Value);    
    }
    catch (Exception)
    {
    
    }
    finally
    {                
        cmd.Connection.Close();
        Response.Write(result); 
    }
