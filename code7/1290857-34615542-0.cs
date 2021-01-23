    protected void SubmitAll_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < CheckOpenTimesheets.Items.Count; i++)
        {
            
            if 
            {
                String sql2 = "UPDATE Periods SET PeriodStatus_ID=5 WHEREUser_ID = @userid AND StartDate = @startdate";
                command.Parameters.Add(new SqlParameter("userid", ddlActingAs.SelectedValue.ToString()));
                command.Parameters.Add(new SqlParameter("startdate", item.Items(i).Value);
            }
        }
    }
