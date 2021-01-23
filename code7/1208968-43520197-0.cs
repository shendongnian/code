       protected void grd1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TextBox txt = (TextBox)e.Row.FindControl("txtTaskName");
				DropDownList ddlTaskStatus = (DropDownList)e.Row.FindControl("ddlTaskStatus");
                Label lblSerialNoCat1 = (Label)e.Row.FindControl("lblSerialNoCat1");
		    }
		}
