    foreach (DataGridViewColumn dc in dataGridView1.Columns)
    {
        if (dc.Index.Equals(0))
        {
            dc.ReadOnly = false;
        }
        else
        {
            dc.ReadOnly = true;
        }
    }
