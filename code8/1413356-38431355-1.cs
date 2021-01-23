    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        DataGridViewCell cell = dataGridView1[e.ColumnIndex, e.RowIndex];
        if (cell.OwningColumn.CellType == typeof(DataGridViewButtonCell) 
        && cell.ReadOnly) Console.Write("This Cell is Disabled");
    }
