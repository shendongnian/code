    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
    
    	CheckBox chkTest = (CheckBox)sender;
    	GridViewRow grdRow = (GridViewRow)chkTest.NamingContainer;
    	int index = (int)GridView1.DataKeys[grdRow.RowIndex].Value;
    	if (chkTest.Checked)
    	{
    		if (!SelectedCategories.Contains(index))
    			SelectedCategories.Add(index);
    		grdRow.BackColor = System.Drawing.Color.Yellow;
    	}
    	else
    	{
    		if (SelectedCategories.Contains(index))
    			SelectedCategories.Remove(index);
    		grdRow.BackColor = System.Drawing.Color.White;
    	}
    	if (SelectedCategories.Count >= 5)
    	{
    		btnUpdate.Enabled = true;
    		btnUpdate.CssClass = "enabledImageButton";
    	}
    	else
    	{
    		btnUpdate.Enabled = false;
    		btnUpdate.CssClass = "disabledImageButton";
    	}
    }
