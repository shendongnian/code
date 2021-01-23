    protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
    {
		dt = new DataTable(); // Assuming that dt is a local variable
		foreach (ListItem li1 in CheckBoxListBranch.Items)
		{
			if (li1.Selected)
				dt.Rows.Add(li1.Text);
		}
		GVDisplay.DataSource = dt;
        GVDisplay.DataBind();
	}
