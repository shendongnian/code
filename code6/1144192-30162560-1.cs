     List<String> user = new List<String>(); 
           
     List<int> notifyId = new List<int>();
        
            using (SqlConnection conn = new SqlConnection())
               {
               try
                 {
                conn.ConnectionString = "data source=servername;User ID=username;Password=oasswordn;initial catalog=database;integrated security=False;MultipleActiveResultSets=True;App=EntityFramework";
                conn.Open();
            
              SqlCommand cmd = new SqlCommand("SELECT id,email FROM test", conn);
              SqlDataReader rd = cmd.ExecuteReader(); 
            while (rd.Read()) 
               {
                            notifyId.Add(Convert.ToInt16(rd.GetValue(0)));
                            user.Add(rd.GetValue(1).ToString());
                                
                        }
            if(user.Count > 0)
                {
                    for (int i = 0; i < user.Count; i++)
                    MessageBox.Show(user[i].ToString());
                }
             rd.Close();
            
             cmd = new SqlCommand("DELETE FROM test WHERE id =@id ", conn);
            for (int i = 0; i < notifyId.Count; i++)
               {
                   cmd.Parameters.Clear();//clear the parameter on each loop
                   cmd.Parameters.AddWithValue("@id", notifyId[i]);
                    cmd.ExecuteNonQuery();
                }
               conn.Close();
              }
                  catch(Exception e1)
                    {
            
                     }
         }
