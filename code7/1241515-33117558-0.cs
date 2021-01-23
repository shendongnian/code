    private void RadGrid1_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {
    	if ((e.Item is GridDataItem)) {
    		GridDataItem item = e.Item;
    		DropDownList list = (DropDownList)item.FindControl("ddlProgramme");
    		list.SelectedValue = DataBinder.Eval(item.DataItem, "<Datafield_name>").ToString();
    	}
    }
