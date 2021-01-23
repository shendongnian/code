    public static void CreateDrugsListBox(CheckedListBox DrugsList) 
       {
           try
           {
               SqlConnection con = new SqlConnection(@"connection");
               SqlCommand cmd = new SqlCommand("InsertData_DrugsListBox", con);
               cmd.CommandType = CommandType.StoredProcedure;
    
               con.Open();
               
              
                for (int i = 0; i < DrugsList.Items.Count; i++)
                {
                    if (DrugsList.GetItemChecked(i))
                    {
                        string str = (string)DrugsList.Items[i];
                        
                    cmd.Parameters.Clear();           
                   cmd.Parameters.AddWithValue("@DrugsValue", str); 
                   cmd.ExecuteNonQuery();
                    }
                }
               con.Close();
          }
    
           catch (Exception ex)
           {
    
               MessageBox.Show("Error"+ex, "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
    
           }
    
       }
