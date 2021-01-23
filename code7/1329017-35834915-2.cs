    List<string> rowHeaders = new List<string> { "A", "B", "C", "D", "E", "F", "G" };
    for (int i = 0; i < dataGridView1.Rows.Count; i++)
    {
        dataGridView1.Rows[i].HeaderCell.Value = rowHeaders[i];
    }
