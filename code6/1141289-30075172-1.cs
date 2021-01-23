    private void insert_Click(object sender, EventArgs e)
            {
               insert(list1);
                
            }
        private void insert(CheckedListBox list1)
         {
        using (SqlConnection conn = new SqlConnection())
          {
          try
          {
         conn.ConnectionString = "data source=servername;User ID=user_name;Password=password;initial catalog=database_name;integrated security=False;MultipleActiveResultSets=True;App=EntityFramework";
        conn.Open();
        
        SqlCommand cmd = new SqlCommand("InsertData_CityListBox", conn);
         cmd.CommandType = CommandType.StoredProcedure;
          for (int i = 0; i < list1.Items.Count; i++)
          {
           if (list1.GetItemChecked(i))
           {
       string str = (string)list1.Items[i]; //Or try  list1.Items[i].ToString();
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@city_code", str);
            cmd.ExecuteNonQuery();
          }
        }
                conn.Close();
             }
          catch(Exception e1)
            {
        
               }
        
          }
        }
