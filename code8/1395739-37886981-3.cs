    for (int i = 0; i <= 40; i++)
    {
        dataGridView1.Columns.Add("column" + i.ToString(), i.ToString());
        dataGridView1.Columns[i].Width = 22;
    }
    DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();        
    for (int i = 0; i <= 40; i++)
    {
        row.Cells[i].Value = scores[0,i]; // "scores" is an Int32[,] array filled with my data
    }
    dataGridView1.Rows.Add(row);
    dataGridView1.Rows[0].HeaderCell.Value = "Score";
