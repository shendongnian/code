    private DataTable table; 
    private SqlDataAdapter dataAdapter;
    private void sampleForm_Load(object sender, EventArgs e)
    {
        var command = "SELECT * FROM Table1";
        var connection = @"Your connection string";
        table = new DataTable();
        dataAdapter = new SqlDataAdapter(command, connection);
        var commandBuilder = new SqlCommandBuilder(dataAdapter);
        dataAdapter.Fill(table);
        //Set false as default value for Column2
        table.Columns["Column2"].DefaultValue = false;
        var column1 = new DataGridViewTextBoxColumn();
        column1.Name = "Column1";
        column1.DataPropertyName = "Column1";
        var column2 = new DataGridViewCheckBoxColumn();
        column2.Name = "Column2";
        column2.DataPropertyName = "Column2";
        column2.TrueValue = "Y";
        column2.FalseValue = "N";
        this.dataGridView1.Columns.Add(column1);
        this.dataGridView1.Columns.Add(column2);
        //Bind grid to table
        this.dataGridView1.DataSource = table;
    }
    private void saveButton_Click(object sender, EventArgs e)
    {
        //Save data
        this.dataGridView1.EndEdit();
        dataAdapter.Update(table);
    }
