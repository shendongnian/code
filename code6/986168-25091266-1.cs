    private SqlConnection connection;
    private SqlDataAdapter adapter;
    private SqlCommandBuilder builder;
    private DataTable table;
    private void Form1_Load(object sender, EventArgs e)
    {
        connection = new SqlConnection("connection string here");
        adapter = new SqlDataAdapter("SELECT * FROM Person", connection);
        builder = new SqlCommandBuilder(adapter);
        table = new DataTable();
        adapter.Fill(table);
        bindingSource1.DataSource = table;
        dataGridView1.DataSource = bindingSource1;
        givenNameTextBox.DataBindings.Add("Text", bindingSource1, "GivenName");
        familyNameTextBox.DataBindings.Add("Text", bindingSource1, "FamilyName");
    }
    private void addButton_Click(object sender, EventArgs e)
    {
        bindingSource1.AddNew();
    }
    private void deleteButton_Click(object sender, EventArgs e)
    {
        bindingSource1.RemoveCurrent();
    }
    private void saveButton_Click(object sender, EventArgs e)
    {
        bindingSource1.EndEdit();
        adapter.Update(table);
    }
