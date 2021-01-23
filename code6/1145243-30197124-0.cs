    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
      if (dataGridView1.CurrentCell is DataGridViewCheckBoxCell)
      {
        dataGridView1.CurrentCell = dataGridView1.CurrentRow.Cells[e.ColumnIndex + 1];
        dataGridView1.BeginEdit(true);
      }
    }
