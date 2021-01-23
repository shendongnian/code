    DataGridViewColumn[] arr = 
    retriever.Columns.Select(d=>new DataGridViewColumn()
    {Name = d.ColumnName,HeaderText = d.ColumnName}).ToArray();
    dataGridView1.Columns.AddRange(arr);
       
