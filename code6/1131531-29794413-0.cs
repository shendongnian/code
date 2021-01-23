    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            var nonUpdatedRows = new List<int>();
            var employees = new List<EmployeeGroup>();
            foreach (GridViewRow row in gvDetails.Rows)
            {
                string strID = ((Label)row.FindControl("lblID")).Text;
                string strGroup = ((Label)row.FindControl("lblGrp")).Text;
                string strValue = ((TextBox)row.FindControl("txtValue")).Text;
                string strOldValue = ((HiddenField)row.FindControl("hdnOldValue")).Value;
                if(strValue != strOldValue)
                {
                    //because if nonUpdatedRows.Count > 0, 
                    //we dont need to fill the list for updation further
                    if(nonUpdatedRows.Count == 0)
                    {
                        employees.Add(new EmployeeGroup
                            {
                                ID = strID,
                                Group = strGroup,
                                Value = strValue
                            });
                    }
                }
                else
                {
                    nonUpdatedRows.Add(row.RowIndex + 1);
                }
            }
            if (nonUpdatedRows.Count == 0)
            {
                foreach (var employee in employees)
                {
                    //TO DO: Update here
                }
            }
            else
            {
                var errorMessage = String.Format(
                    "The following rows are not updated:{0} ", 
                    String.Join(", ", nonUpdatedRows));
                // do something with the errormessage
            }
        }
        catch (Exception ex)
        {
        }
    }
