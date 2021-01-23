    using (OracleCommand cmd = new OracleCommand(<query>/<stored proc>, con))
    {    
    cmd.CommandType = CommandType.StoredProcedure;  //in case of stored proc
    cmd.BindByName = true;
    OracleDataReader reader;
    try
      {
        reader = cmd.ExecuteReader();    
        while(reader.Read())
        {
            Console.WriteLine("field: {0}", reader.GetDecimal(0));  
        }    
      }
    catch (OracleException e)
      {
      foreach (OracleError err in e.Errors)
        {
           //print errors         
         }
       }
     con.Close(); 
    }
    
