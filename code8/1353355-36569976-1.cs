	protected void ItemsFormView_DataBound(object sender, EventArgs e)
	{
		If (FormView1.CurrentMode == FormViewMode.Insert){
			DataRowView dataRow = ((DataRowView)FormView1.DataItem);
			if (Convert.ToInt16(dataRow["ClStk"]) <= 0)
			{
				Label lbl = (Label)FormView1.FindControl("lblStock");
				lbl.CssClass = "changefont";
			}
		}
	}
	
	
