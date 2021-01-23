    // i believe this fires on load *and* when editing.
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      DataRowView dRowView = (DataRowView)e.Row.DataItem;
      if (e.Row.RowType == DataControlRowType.DataRow)
      {
        // editing:
        if ((e.Row.RowState & DataControlRowState.Edit) > 0)
        {
          // find the controls.
          RadioButtonList rblGender = (RadioButtonList)e.Row.FindControl("rbGenderEdit");
          DropDownList ddlStatus = (DropDownList)e.Row.FindControl("ddlStatusEdit");
          // set the values.
          rblGender.SelectedValue = dRowView[2].ToString();
          ddlStatus.SelectedValue = dRowView[3].ToString();
        }
      }           
    }
       
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
      // find the controls.
      RadioButtonList rblGender = (RadioButtonList)GridView1.Rows[e.RowIndex].FindControl("rbGenderEdit");
      DropDownList ddlStatus = (DropDownList)GridView1.Rows[e.RowIndex].FindControl("ddlStatusEdit");
      // set the values.
      SqlDataSource1.UpdateParameters["Sex"].DefaultValue = rblGender.SelectedValue;
      SqlDataSource1.UpdateParameters["MaritalStauts"].DefaultValue = ddlStatus.SelectedValue;
    }
