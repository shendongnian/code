    private void dgComputers _CellValidating(object sender,
                                             DataGridViewCellValidatingEventArgs e)
    {
        // maybe add checks to see if this is the right one!?
        DataGridViewComboBoxCell comboCell =
            dgComputers[e.ColumnIndex, e.RowIndex] as DataGridViewComboBoxCell;
        if (comboCell != null)
            if (!comboCell.Items.Contains(e.FormattedValue))
                comboCell.Items.Add(e.FormattedValue);
    }
