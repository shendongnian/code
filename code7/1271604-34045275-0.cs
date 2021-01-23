    public bool AddColumns(DataGridViewColumn dgvColumn)
    {
        if (dgvColumn == null)
        {
            return false;
        }
        dataGridView1.Columns.Add(dgvColumn);
        return true;
    }
