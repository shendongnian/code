    SqlConnection conn = new SqlConnection(GetConnectionString());
    SqlCommand cmd = new SqlCommand();
    cmd.Connection = conn;
    
    conn.Open();
    
    foreach (ListItem item in CheckBoxList1.Items)
    {
    	if(item.Selected)
    	{
    
    		cmd.CommandType = CommandType.StoredProcedure;
    		cmd.CommandText = "[dbo].[AccountCode_Update]";
    		cmd.Parameters.AddWithValue("@Batch_Num", SqlDbType.Int).Value = i;
    		cmd.Parameters.AddWithValue("@Batch_Date", SqlDbType.DateTime).Value = dt;
    		cmd.Parameters.AddWithValue("@Account_Code", SqlDbType.VarChar).Value = BatchCodeList.SelectedValue;
    		
    		cmd.ExecuteNonQuery();
    	}
    }
    
    conn.Close();
