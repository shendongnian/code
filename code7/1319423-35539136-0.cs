    private void LoadDataGridView(int ID)
    {
        try
        {
             SqlConnection connection = new SqlConnection(connString);
             SqlCommand cmd = new SqlCommand();
             cmd.CommandText = "SELECT * FROM Sentences WHERE CategoryID = @ID";
             cmd.Connection = connection;
             cmd.Parameters.Add("@ID",SqlDbType.Int).Value = ID;
             dataTable = new DataTable();
             SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
             dataAdapter.Fill(dataTable);
             dataGridView.DataSource = dataTable;
             dataGridView.Columns[0].Visible = false;
             dataGridView.Columns[2].Visible = false;
       }
       catch (Exception)
       {
             MessageBox.Show("ERROR WHILE CONNECTING WITH DATABASE!");
       }
    }
