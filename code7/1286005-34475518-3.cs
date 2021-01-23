    // This part never changes so, set it up just one time before the loop
    sqlCmd.Connection = sqlConn;
    sqlCmd.CommandType = CommandType.StoredProcedure;
    sqlCmd.CommandText = "spInsFormRegistrant";
    sqlCmd.Parameters.Add("@EventId", SqlDbType.Int).Value = eventId;
    sqlCmd.Parameters.Add("@FormId", SqlDbType.Int).Value = formId;
    // These twos change inside the loop, so we don't need the value here
    sqlCmd.Parameters.Add("@ColumnName", SqlDbType.NVarChar);
    sqlCmd.Parameters.Add("@ColumnValue", SqlDbType.NVarChar);
    
    
    foreach (RepeaterItem rpItem in RepeaterForm.Items)
    {
        Label lblDisplayName = rpItem.FindControl("lblDisplayName") as Label;
        Label lblColumnName = rpItem.FindControl("lblColumnName") as Label;
        TextBox txtColumnValue = rpItem.FindControl("txtColumnValue") as TextBox;
    
        if (txtColumnValue != null)
        {
            sqlCmd.Parameters["@ColumnName"].Value = lblColumnName.Text;
            sqlCmd.Parameters["@ColumnValue"].Value = txtColumnValue.Text;
            sqlCmd.ExecuteNonQuery();
        }
    }
