    void editCombo_TextChanged(object sender, EventArgs e)
    {
        List<String>  items = allChoices.Select(x=>x)
                                        .Where(x=>x.Contains(editCombo.Text)).ToList();
        if (items.Count > 0)
        {
            editCombo.Items.Clear();
            editCombo.Items.AddRange(items.ToArray());
        }
        editCombo.Select(editCombo.Text.Length, 0);  //clear the selection
    }
