    protected void gvProducts_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // find gender from label which is inside ItemTemplate
            string lblgender = ((Label)e.Row.FindControl("gender")).Text;
            if ((e.Row.RowState & DataControlRowState.Edit) > 0)
            {
                // find gender list from dropdownlist which is inside EditTemplate
                DropDownList genderList = (DropDownList)e.Row.FindControl("DDL_genderList");
                genderList.SelectedIndex = 
                    genderList.Items.IndexOf(genderList.Items.FindByValue(lblgender));
            }
        }
    }
