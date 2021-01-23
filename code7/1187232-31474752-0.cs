    DataGridViewColumn[] column_array = new DataGridViewColumn[retriever.Columns.Count];
        
        for (int cnt = 0;cnt < retriever.Columns.Count;cnt++)
        {
            DataGridViewColumn col = new DataGridViewColumn();
            col.Name = retriever.Columns[cnt].Name;
            col.HeaderText = retriever.Columns[cnt].HeaderText;
            column_array[cnt] = col;
        }
        
         dataGridView1.Columns.AddRange(column_array);
