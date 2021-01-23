    List<People> ppl = ((DataGridViewComboBoxColumn)this.dataGridView1.Columns[0]).DataSource as List<People>;
    foreach (DataGridViewRow row in this.dataGridView1.Rows)
    {
        if (row.Index != this.dataGridView1.NewRowIndex)
        {
            var cell = row.Cells[0] as DataGridViewComboBoxCell;
            People person = ppl.SingleOrDefault(p => p.Name == cell.Value.ToString());
            if (person != null)
            {
                Console.WriteLine("{0} {1}, {2}", person.ID, person.Name, row.Cells[1].Value);
            }
        }
    }
