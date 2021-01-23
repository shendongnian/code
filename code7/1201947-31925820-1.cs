     protected void grdchkbox_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if(e.Row.RowType == DataControlRowType.DataRow)
        {
            CheckBox chkbox1 = (e.Row.FindControl("Checkbox1") as CheckBox);
            //we check to see if we already have the users status saved in session
            var isUser = HttpContext.Current.Session["IsGeneralUser"];
            //if we dont, we run the IsGeneralUser method and save the result in session
            if(isUser == null)
            {
                isUser = IsGeneralUser(empid);
                HttpContext.Current.Session.Add("IsGeneralUser", isUser);
            }
            if (Convert.ToBoolean(isUser))
            {
                chkbox1.Enabled = false;
            }
        }
    }  
