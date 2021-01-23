    protected void EmployeeAvailabilityGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {                  
                if(DataBinder.Eval(e.Row.DataItem, "Health_Comment_Status") == "R")
                {
                    e.Row.Cell[2].BackColor = System.Drawing.Color.Red;
                }
            }
        }
        catch (Exception ex)
        {
            //ErrorLabel.Text = ex.Message;
        }
    }
