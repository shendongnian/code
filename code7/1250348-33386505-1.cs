    try   
    {   
       con.Open();   
       SqlCommand cmd = new SqlCommand(query, con);   
    
       cmd.ExecuteNonQuery();    
       con.Close();    
     }    
     catch (Exception ex)
     {
     }
     finally
     {
        con.close();
     }
