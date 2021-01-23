	dataGridView1.Columns.AddRange(retriever.Columns.Cast<DataColumn>().Select(n =>
		{
			return new DataGridViewColumn
	        {
	            Name = n.ColumnName,
	            HeaderText = n.ColumnName
	        };
		}));	
