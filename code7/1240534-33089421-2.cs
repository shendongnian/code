            public void typeColumnDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            DataGridView dataGridView = sender as DataGridView;
            if (dataGridView == null) return;
            if (!dataGridView.CurrentCell.IsInEditMode) return;
            if (dataGridView.CurrentCell.GetType() != typeof (DataGridViewComboBoxCell)) return;
            DataGridViewComboBoxCell cell = (DataGridViewComboBoxCell)dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
            if (cell.Items.Contains(e.FormattedValue)) return;
            cell.Items.Add(e.FormattedValue);
            cell.Value = e.FormattedValue;
            if (((DataGridViewComboBoxColumn) dataGridView.Columns[0]).Items.Contains(e.FormattedValue)) return;
            ((DataGridViewComboBoxColumn)dataGridView.Columns[0]).Items.Add(e.FormattedValue);
        }
