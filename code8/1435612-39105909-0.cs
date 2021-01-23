     foreach (ListItem item in CheckBoxList1.Items)
     {
         if(item.Selected)
         {
    
              cmd.CommandType = CommandType.StoredProcedure;
              cmd.CommandText = "[dbo].[AccountCode_Update]";
              cmd.Parameters.AddWithValue("@Batch_Num", SqlDbType.Int).Value = i;
              cmd.Parameters.AddWithValue("@Batch_Date", SqlDbType.DateTime).Value = dt;
              cmd.Parameters.AddWithValue("@Account_Code", SqlDbType.VarChar).Value = BatchCodeList.SelectedValue;
              conn.Open();
              cmd.ExecuteNonQuery();
              conn.Close();
              cmd.Parameters.Clear(); // you need to clear previous parameters
         }
    
    
      }
  
