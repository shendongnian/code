    public void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
    {
        if (e.ColumnIndex >= 0 && e.ColumnIndex < 3)
        {
            for (int col = 0; col < 3; col++)
            {
                if (string.IsNullOrEmpty(this.dataGridView1[col, e.RowIndex].EditedFormattedValue.ToString()))
                {
                    MessageBox.Show("Value can't be null.");
                    e.Cancel = true;
                    this.dataGridView1.CellValidating -= dataGridView1_CellValidating;
                    this.dataGridView1.CurrentCell = this.dataGridView1[col, e.RowIndex];
                    this.dataGridView1.BeginEdit(true);
                    this.dataGridView1.CellValidating += dataGridView1_CellValidating;
                    return;
                }
            }
        }
    }
