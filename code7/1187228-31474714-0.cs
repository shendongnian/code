	dataGridView1.Columns.AddRange(retriever.Columns.Select(n =>
		{
			new DataGridViewColumn
	            {
	                Name = n.ColumnName,
	                HeaderText = n.ColumnName
	            };
		}));	
