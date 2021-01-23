    protected void SubmitAll_Click(object sender, EventArgs e)
    {
         SqlCommand command = new SqlCommand();
         command.Connection = gConn;
         String sql = "UPDATE Periods SET PeriodStatus_ID=5 WHERE User_ID = @userid AND StartDate = @startdate";
         command.CommandText = sql;
         command.Parameters.Add("userid");
         command.Parameters.Add("startdate");
        for (int i = 0; i < CheckOpenTimesheets.Items.Count; i++)
        {
            
         if (item.Selected == true)
         {
            command.Parameters("userid").Value = ddlActingAs.SelectedValue.ToString();
            command.Parameters("startdate").Value = item.Value;
            command.ExecuteNonQuery();
            }
        }
    }
