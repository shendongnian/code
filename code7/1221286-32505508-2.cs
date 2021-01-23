    void Main()
    {
    	SqlConnection conn = new SqlConnection("Data Source=(local);Initial Catalog=aaa;Persist Security Info=True;User ID=-----;Password=------+");
                SqlCommand cmd = new SqlCommand(
									@"SELECT * FROM cities; 
									SELECT city as secondBulkCity FROM cities; 
									SELECT  city as thirdBulkCity from cities; 
									SELECT  city as fourthBulkCity from cities  WHERE city like '" + "new" + "%'", conn);
                conn.Open();
    
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
    			"".Dump("first bulk");
                    while (dr.Read())
                    {       
                     dr["city"].Dump();
                    }
    				
    			"".Dump("second bulk");
                     if (dr.NextResult())
                    {
                        while (dr.Read())
                        {
                            dr["secondBulkCity"].Dump();
                        }
                    }
    				
    		   "".Dump("third bulk");
                    if (dr.NextResult())
                    {
                        while (dr.Read())
                        {
                           dr["thirdBulkCity"].Dump();
                        }
                    }
    	     	"".Dump("fourth bulk");
                    if (dr.NextResult())
                    {
                        while (dr.Read())
                        {
                           dr["fourthBulkCity"].Dump();
                        }
                    }
    }
    
     
    }
