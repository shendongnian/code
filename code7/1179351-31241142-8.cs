    protected void RadComboBox1_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        if (RadComboBox1.SelectedItem != null)
        {
            GridCommandItem cmditem = (GridCommandItem)RadGrid1.MasterTableView.GetItems(GridItemType.CommandItem)[0];
            System.Web.UI.WebControls.Button ctrl = (System.Web.UI.WebControls.Button)cmditem.FindControl("AddNewRecordButton");
            ctrl.Enabled = false;
    
            System.Web.UI.WebControls.LinkButton btn = (System.Web.UI.WebControls.LinkButton)cmditem.FindControl("InitInsertButton");
            btn.Enabled = false;
        }
    	
    	else
    	{
    		// alert
    	}
    }
