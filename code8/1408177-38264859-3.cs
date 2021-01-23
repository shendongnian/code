    static float ExecuteQueryWithResult_fl(SqlConnection connection, string query)   {
                try {        
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        var prev_val = command.ExecuteScalar().ToString() == null ? default(float) : float.Parse(command.ExecuteScalar().ToString());;
                        return prev_val;
                    }
                }
              
               catch (Exception x) 
    		   { 
    		   		Console.WriteLine("Error fetching due to {0}", x.Message); 
    				return default(float);
    		   }
         }
