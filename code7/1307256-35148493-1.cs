    private void dgComputers _CellValidating(object sender,
                                             DataGridViewCellValidatingEventArgs e)
    {
        // maybe add checks to see if you want to make this one editable!?
        DataGridViewComboBoxCell comboCell =
            dgComputers[e.ColumnIndex, e.RowIndex] as DataGridViewComboBoxCell;
            if (comboCell != null)
                if (!comboCell.Items.Contains(e.FormattedValue))
                    comboCell.Items.Add(e.FormattedValue);
    }
