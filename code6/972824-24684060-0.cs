     protected void gridview1_DataBound(object sender, GridViewRowEventArgs e)
     {
          if (e.Row.RowType == DataControlRowType.DataRow)
          {
              HiddenField hiddenOriginalStatus = (HiddenField)e.Row.FindControl("hiddenOriginalStatus");
              (e.Row.FindControl("ddlTransactionList") as DropDownList).Attributes.Add("onchange", "ConfirmStatus('" + hiddenOriginalStatus.Value + "');");
          }
     }
