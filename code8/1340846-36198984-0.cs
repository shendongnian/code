    for (int i = 0; i < dataset.ColumnCount; ++i)
    {
        dataGridView1.ColumnCount++;
        dataGridView1.Columns[i].Name = dataset.ColumnNames[i];
    }
    
    for (int i = 0; i < dataset.RowCount; ++i)
    {
        dataGridView1.RowCount++;
        dataGridView1.Rows[i].HeaderCell.Value = dataset.RowNames[i];
    
        for (int k = 0; k < dataset.ColumnCount; ++k)
        {
            dataGridView1[k, i].Value = dataset[i,k];
        }
    }
