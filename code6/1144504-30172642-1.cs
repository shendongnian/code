    protected void btnDelete_Click(object sender, EventArgs e)
    {
        List<string> customersToDelete = new List<string>();
        foreach(GridViewRow row in GridView1.Rows)
        {
            CheckBox chkDelete = (CheckBox)row.FindControl("chkDelete");
            if(chkDelete.Checked)
            {
                DataKey key = GridView1.DataKeys[row.DataItemIndex];
                customersToDelete.Add(key.Value.ToString());
            }
        }
    }
