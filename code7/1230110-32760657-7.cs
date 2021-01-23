    private void _ListView_OnItemClick(object sender, AdapterView.ItemClickEventArgs e)
		{
			{
				CheckBox chk = e.View.FindViewById<CheckBox>(Resource.Id.checkBox1);
				if (chk.Checked == true)
				{
					chk.Checked = false;
					
				}
				else
				{
					chk.Checked = true;
				}
			}
