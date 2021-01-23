    protected void em_contact_list_SelectedIndexChanged(object sender, EventArgs e)
        {
        	var items = this.em_contact_list.SelectedItems;
        
        	foreach ( ListViewItem item in items)
        	{
                var tbox = item.findControl("contact_nameTextBox");
        
                if(tbox != null)
                {
                   string value = ((TextBox)tbox).Text;
                }
        	}
        }
