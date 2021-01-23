    private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
    {
        if (dataGridView1.CurrentCell.ColumnIndex == CategorySelector.Index)
        {
            ComboBox combo = e.Control as ComboBox;
            if (combo == null)
                return;
            combo.DropDownStyle = ComboBoxStyle.DropDown;
            combo.LostFocus += combo_LostFocus;
        }
    }
    void combo_LostFocus(object sender, EventArgs e)
    {
        ComboBox c = (ComboBox)sender;
        if (c.FindStringExact(c.Text.Trim().ToLower()) == -1)
        {
            inventoryCategorySet.Tables[0].Rows.Add(c.Text.Trim().ToLower());
            inventoryCategorySet.AcceptChanges();
        }
    } 
