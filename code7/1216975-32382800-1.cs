    protected void ButtonUpdate_Click(object sender, EventArgs e)
    {
        var selectedIds = new List<string>();
        foreach (ListItem item in CheckBoxListList.Items)
        {
            if (item.Selected) 
            {
               selectedIds.Add(item.Value);
            }
        }
    }
