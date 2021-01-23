    private void chkBox_CheckedChanged(object sender, EventArgs e)
		{
			CheckBox tmp = (CheckBox)sender;
			bool tmpStatus = tmp.Checked;
			foreach (CheckBox chk in this.Controls.OfType<CheckBox>())
			{
				if (tmp.Checked)
				{
					chk.Enabled = false;
					tmp.Enabled = tmpStatus;
				}
				else
				{
					chk.Enabled = true;
					tmp.Enabled = true;
				}
			}
		}
