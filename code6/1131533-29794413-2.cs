    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            var isAnyRowUpdated = false;
            foreach (GridViewRow row in gvDetails.Rows)
            {
                string strID = ((Label)row.FindControl("lblID")).Text;
                string strGroup = ((Label)row.FindControl("lblGrp")).Text;
                string strValue = ((TextBox)row.FindControl("txtValue")).Text;
                string strOldValue = ((HiddenField)row.FindControl("hdnOldValue")).Value;
                if (strValue != strOldValue)
                {
                    isAnyRowUpdated = true;
                    //update procedure here.
                }
                //now check if the flag is still false
                //that means no rows are changed
                if(!isAnyRowUpdated)
                {
                    //alert no rows are updated
                }
            }
        }
        catch (Exception ex)
        {
        }
    }
