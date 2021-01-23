    var c = this.EditingControlDataGridView
                .Columns[this.EditingControlDataGridView.CurrentCell.ColumnIndex]
                as DataGridViewComboBoxColumn;
    if (c != null)
        c.Items.Add("Something");
