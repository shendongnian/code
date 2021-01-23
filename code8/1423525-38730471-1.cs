           using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
          {
               SqlCommand cmd = new SqlCommand();
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.CommandText = "dbo.GetUser";  
               cmd.Connection = cn;
               cn.Open();
               using (IDataReader dr = cmd.ExecuteReader())
               {
               while (dr.Read()) 
                                   string temp = string.Empty;
            int fc = dr.FieldCount;    
            if (fc>0)
            {
                            object val2 = dr[0];
                            temp = val1.GetType().ToString();
            }
            if (fc>1)
            {
                            object val2 = dr[1];
                            temp = val2.GetType().ToString();
            }
            
            
            temp = "did I get here?";
            string firstName = (string)dr[0];
            string lastName = (string)dr[1];                        
            return firstName + " " + lastName;
        }
               }
               }
