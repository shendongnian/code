    foreach (RepeaterItem rpItem in RepeaterForm.Items)
    {
    	Label lblDisplayName = rpItem.FindControl("lblDisplayName") as Label;
    	Label lblColumnName = rpItem.FindControl("lblColumnName") as Label;
    	TextBox txtColumnValue = rpItem.FindControl("txtColumnValue") as TextBox;
    
    	if (txtColumnValue != null)
    	{
    		sqlCmd.Connection = sqlConn;
    		sqlCmd.CommandType = CommandType.StoredProcedure;
    		sqlCmd.CommandText = "spInsFormRegistrant";
    		sqlCmd.Parameters.Clear();	//that's fine, keep it
    
    		//just put them in here
    		sqlCmd.Parameters.Add("@EventId", SqlDbType.Int).Value = eventId;
    		sqlCmd.Parameters.Add("@FormId", SqlDbType.Int).Value = formId;
    
    		sqlCmd.Parameters.Add("@ColumnName", SqlDbType.NVarChar).Value = lblColumnName.Text;
    		sqlCmd.Parameters.Add("@ColumnValue", SqlDbType.NVarChar).Value = txtColumnValue.Text;
    
    	sqlCmd.ExecuteNonQuery();
    	}
    }
