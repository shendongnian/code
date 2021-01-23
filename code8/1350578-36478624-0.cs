    var column1 = new DataGridViewTextBoxColumn();
    column1.DataPropertyName = "Property1";
    column1.HeaderText = "Column1";
    var column2 = new DataGridViewTextBoxColumn();
    column2.DataPropertyName = "Property2";
    column2.HeaderText = "Column2";
    this.dataGridView1.Columns.Add(column1);
    this.dataGridView1.Columns.Add(column2);
    this.dataGridView1.AutoGenerateColumns = false;
    this.dataGridView1.DataSource = Enumerable.Range(1, 10)
                                                .Select(x => new 
                                                { 
                                                    Property1 = x,
                                                    Property2 = x, 
                                                    Property3 = x
                                                }).ToList();
