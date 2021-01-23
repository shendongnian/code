    private void ListBindingSource_CurrentChanged(object sender, EventArgs e)
        {
        DataRowView rowView = (DataRowView)ListBindingSource.Current;
        string query = "Inner Join SQL Query Table 2 & 3 /w Where PID = rowView[PIDColumn]";
        SqlConnection connection = new SqlConnection("SQL Connection");
        connection.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = query;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable SQLResultTable = new DataTable();
        da.Fill(SQLResultTable);
        dataGridView1.DataSource = SQLResultTable;
        }
