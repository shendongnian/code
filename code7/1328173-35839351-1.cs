    protected void GrdWorkingCompany_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        CheckBox chkbox = (CheckBox)e.Row.FindControl("cbTest");
        chekbox.Enable = false; 
    }
