    protected void SubmitAll_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < CheckOpenTimesheets.Items.Count; i++)
        {
            
         SqlCommand command = new SqlCommand();
         command.Connection = gConn;
         if (item.Selected == true)
         {
            String sql = "UPDATE Periods SET PeriodStatus_ID=5 WHERE User_ID = @userid AND StartDate = @startdate";
            command.CommandText = sql;
            command.Parameters.Add(new SqlParameter("userid", ddlActingAs.SelectedValue.ToString()));
            command.Parameters.Add(new SqlParameter("startdate", item.Value));
            command.ExecuteNonQuery();
            }
        }
    }
