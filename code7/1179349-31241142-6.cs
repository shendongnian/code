    protected void RadComboBox1_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        if (RadComboBox1.SelectedItem != null)
        {
            GridCommandItem cmditem = (GridCommandItem)RadGrid1.MasterTableView.GetItems(GridItemType.CommandItem)[0];
            Control ctrl = cmditem.FindControl("AddNewRecordButton");
            ctrl.Visible = false;
    
            LinkButton btn = (LinkButton)cmditem.FindControl("InitInsertButton");
            btn.Enabled = false;
        }
    	
    	else
    	{
    		// alert
    	}
    }
