		protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			if(e.Row.RowType == DataControlRowType.DataRow)
			{
				CheckBox myCheckBoxID = e.Row.FindControl("myCheckBoxID") as CheckBox;
			}
			myCheckBoxID.Checked = true;
		}
