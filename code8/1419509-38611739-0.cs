    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0 && e.RowIndex == 3)
            DoSomething(e.RowIndex, e.ColumnIndex);
    }
    public void DoSomething(int row, int column)
    {
        MessageBox.Show(string.Format("Cell({0},{1}) Clicked", row, column));
    }
    private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
    {
        var cell = this.dataGridView1.CurrentCell;
        if (cell != null && e.KeyCode == Keys.Enter &&
            cell.RowIndex >= 0 && cell.ColumnIndex == 3)
        {
            DoSomething(cell.RowIndex, cell.ColumnIndex);
            e.Handled = true;
        }
    }
