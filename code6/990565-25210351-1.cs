    dataGridView1.AutoGenerateColumns = false;
    dataGridView1.Columns.Add(new DataGridViewImageColumn
                                {
                                   DataPropertyName = "YourImageColumnName",
                                   Name = "status"
                                });
    dataGridView1.DataSource = yourDataSource;
    
