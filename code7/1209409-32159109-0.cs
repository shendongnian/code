    try
      {
          using (SqlConnection cn = new SqlConnection(@"Data Source=.; Initial Catalog=Employee1;Persist Security Info=True;User ID=sa;Password=786"))
          {
              using (SqlCommand cmd = cn.CreateCommand())
              {
                  cmd.CommandType = CommandType.StoredProcedure;
                  cmd.CommandText = "dbo.Date";
                  cmd.Parameters.AddWithValue("@DOB", Convert.ToDateTime(textBox1.Text));
                  using (DataTable dt = new DataTable())
                  {
                      dt.Columns.AddRange(new DataColumn[3] { new DataColumn("Employee ID", typeof(string)), new DataColumn("Employee Name", typeof(string)), new DataColumn("Status", typeof(char)) });
                      
                      cn.Open();
                      using (SqlDataReader res = cmd.ExecuteReader())
                      {
                          MessageBox.Show("COmmand Executed Successfully"); 
                           
                          
                          while(res.Read())
                          {                              
                              dt.Rows.Add(res[0].ToString(), res[1].ToString(), res[2].ToString());
                          }                                                  
                          dataGridView1.DataSource = dt;
                      }
                  }
              }
          }
      }
      catch (Exception exp)
      {
          MessageBox.Show(exp.StackTrace);
      }
