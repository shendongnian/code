    private void dataGridView2_CellValueChanged_1(object sender, DataGridViewCellEventArgs e)
    {
        try
        {
            if (e.ColumnIndex == dataGridView2.Columns[8].Index && e.RowIndex>-1)
            {
                DataGridViewComboBoxCell cell = dataGridView2.Rows[e.RowIndex].Cells[dataGridView2.Columns["KeyProblemDescription"].Index] as DataGridViewComboBoxCell;
                if (cell == null)
                    return;
                Guid primaryProblem = new Guid(dataGridView2.Rows[e.RowIndex].Cells[dataGridView2.Columns["PrimaryKeyProblem"].Index].Value.ToString());
                cell.Value = null; //added code
                cell.DisplayMember = "Name";
                cell.ValueMember = "Id";
                cell.DataSource = dbCalling.getPrimaryKeyProblemDescription(primaryProblem);
            }
        }
        catch (Exception)
        {
        }
    }
