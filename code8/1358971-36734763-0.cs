    DataTable table = null;
    using (SqlConnection connection = new SqlConnection(this.connectionString))
    {
        try
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM Something WHERE Id = @Id";
            cmd.Parameters.Add(new SqlParameter("@Id", YourValue));
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                table = new DataTable();
                adapter.Fill(table);
            }
        }
        catch (Exception ex)
        {
            //Handle your exception;   
        }
    }
    dataGridView1.DataSource = table;
