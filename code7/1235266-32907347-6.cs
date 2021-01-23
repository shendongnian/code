    private void CheckedListBoxSample_Load(object sender, EventArgs e)
    {
        var connection = @"data source=(localdb)\v11.0;initial catalog=TestDB;integrated security=True;MultipleActiveResultSets=True;";
        var command = "SELECT Id, Name From Categories";
        var dataAdapter = new System.Data.SqlClient.SqlDataAdapter(command, connection);
        var table = new DataTable();
        dataAdapter.Fill(table);
        var list = table.Rows.Cast<DataRow>()
            .Select(row => new ItemModel
            {
                Id = row.Field<int>("Id"),
                Name = row.Field<string>("Name")
            })
            .ToList();
        this.checkedListBox1.Items.AddRange(list.Cast<object>().ToArray());
    }
