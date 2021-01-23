	int LastIndex = -1;
	bool InhibitIndexChange = false;
	private void CowTypeSelect_SelectedIndexChanged(object sender, EventArgs e)
	{
		if(InhibitIndexChange)
			return;
		DialogResult Result = MessageBox.Show("Type text here", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
		if (Result == DialogResult.No)
		{
			if(LastIndex != -1)
			{
				InhibitIndexChange = true;
				CowTypeSelect.SelectedIndex = LastIndex;
				InhibitIndexChange = false;
			}
			return;
		}
		
		NotGrazingradioButton.Checked = true;
		if (CowTypeSelect.SelectedIndex == 0)
		{
			CowTypeDefaults.LactatingCow(this);
			CowTypeVarlbl.Text = "گاو شیری";
		}
		else if (CowTypeSelect.SelectedIndex == 1)
		{
			CowTypeDefaults.DryCow(this);
			CowTypeVarlbl.Text = "گاو خشک";
		}
		LastIndex = CowTypeSelect.SelectedIndex;
	}
