    dataGridView.AutoGenerateColumns = false;
    dataGridView.Columns.Add(new DataGridViewImageColumn
                                {
                                   DataPropertyName = "YourImageColumnNae",
                                   ColumnName = "ColumnName"
                                });
    dataGridView.DatSource = yourDataSource;
    
