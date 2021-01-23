        protected void Button_Hented_Click(object sender, EventArgs e)
             {
                 string Hejsa;
                 
        // No need to keep on recreating these objects in a loop. 
        SqlConnection conn2 = new SqlConnection();
                             conn2.ConnectionString =
                                 ConfigurationManager.ConnectionStrings["DatabaseConnectionString1"].ToString();
                             SqlCommand cmd2 = new SqlCommand();
                             cmd2.Connection = conn2;
        conn2.Open();
                     foreach (DataGridItem item in GridView1.Items)
                     {
                         CheckBox Cb = item.Cells[0].Controls[1] as CheckBox;
        
        
                         if (Cb.Checked)
                         {
                             Hesja = item.Cells[1].Text.Trim(); // Get the id of checked record
                             
        
                             cmd2.CommandText = "UPDATE Transactioner"
                                 + " SET Afhented = @Afhented"
                                 + " where Id = @Id";
        
        
                             cmd2.Parameters.Add("@Afhented", SqlDbType.NVarChar).Value = "Ja";
                             cmd2.Parameters.Add("@Id", SqlDbType.Int).Value = Hejsa;
        
        
                             
                             cmd2.ExecuteNonQuery();
                            
        
                         }
        
                     }
     conn2.Close();
                     Response.Redirect(Request.RawUrl);
        
                 
                }
