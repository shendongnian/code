    List<String> lt = new List<string>();    
         try{
             if (con.State == System.Data.ConnectionState.Closed)
                  con.Open();
                   cmd.CommandText = qr;\\the query 
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                 foreach(var rows in dt)
                   {lt.Add(rows[0].toString());}
                }
                catch (SqlException exc)
                { MessageBox.Show(exc.Message);  }
