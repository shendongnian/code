    protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Button2.Enabled = false;
    
        foreach (ListItem item in ListBox1.Items)
        {
            if (item.Selected)
            {
                Button2.Enabled = true;
            }
        }
    }
