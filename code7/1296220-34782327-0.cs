    protected void gvwTask_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            gvwTask.EditIndex = e.NewEditIndex;
            Fill();
            var id = Convert.ToInt64(e.Keys[0]); // you need to set DataKeyNames attribute to receive identifier of selected row item in code behind. 
            var ddlWorkStatus = gvwTask.Rows[e.RowIndex].FindControl("ddlWorkStatus") as DropDownList;
            if(ddlWorkStatus != null)
            {
                //var fetchedObject = queried object based on id;
                ddlWorkStatus.SelectedValue = fetchedObject.StatusProperty;
            } 
         }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Error Message", "alert('" + ex.Message.ToString() + "')", true);
        }
    }   
