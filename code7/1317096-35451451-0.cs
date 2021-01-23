    try
    {
        using (IDbCommand cmd = dbConnection.CreateCommand())
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = SpDeleteProduct;
            dbConnection.Open();
            cmd.ExecuteNonQuery();
        }
    }
    catch (SqlConnection ex)
    {
       //Your exception specific code...
    }  
    catch (Exception ex) 
    {
       //Your exception specific code...
    }  
