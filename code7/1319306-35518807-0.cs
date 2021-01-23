	var checkedControls = this.Controls.OfType<CheckBox>()
									   .Where(chk => chk.Checked == true);
									   
	var uncheckedControls = this.Controls.OfType<CheckBox>()
										 .Where(chk => chk.Checked == false);
										 
	if(checkedControls.Count() > 1)
	{
		foreach (CheckBox chkBox in uncheckedControls) chkBox.Enabled = false;
	}
	else
	{
		foreach (CheckBox chkBox in uncheckedControls) chkBox.Enabled = true;
	}
