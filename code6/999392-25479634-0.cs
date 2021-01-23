    public class Connection
    {
       SqlConnection conn;
       SqlCommand cmd;
       public void connclose()
       {
         conn.Close();
       }
       public Connection()
       {   
           conn = new SqlConnection(@"server=ADMIN-PC;database=sample;Integrated security=true");        
           cmd = null;
       }
       public void nonquery(string qry, string[] arrParams, string[] arrParamsVals)
       {          
          try
          {
              conn.Open();
              cmd = new SqlCommand(qry, conn);
        
              for(int i=0; i < arrParams.Length; i++)
                 cmd.Paratmeters.AddWithValue(arrParams[i], arrParamsVals[i]);
              cmd.ExecuteNonQuery();
               
          }
          catch{}
          finally { conn.Close(); }          
       }
     }
