    DataGridViewComboBoxCell cell = new DataGridViewComboBoxCell();
    cell.Items.AddRange("88", "LinearCurve", "NonLinearCurve");
    cell.Value = cell.Items[0];
    cell.ReadOnly = false;
    dataGridView1.Rows[0].Cells[0] = cell;
