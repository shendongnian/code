    List<String> lt = new List<string>();    
         try{
             if (con.State == System.Data.ConnectionState.Closed)
                  con.Open();
                   cmd.CommandText = qr;\\the query 
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                 for(int i=0;i<dt.Rows.Count;i++)
                   {lt.Add(dt.Rows[i][0].toString());}
                }
                catch (SqlException exc)
                { MessageBox.Show(exc.Message);  }
