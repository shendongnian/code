    private void btnInesrtDate_Click(object sender, EventArgs e)
    {
        string sql = "Insert Into BirthDates (Name, DateOfBirth) Values (@Name, @BirthDate)";
        // Always parameterize your query... it's more secure and less prone to errors
        DateTime birthday = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[2].Value);
        command.Parameters.AddWithValue("@Name", txtName.Text);
        command.Parameters.AddWithValue("@BirthDate", birthday);
        conn.Open();
        // Use a Try/Finally block to so the connection is closed even if an exception occurs
        try
        {
            using (var command = new SqlCommand(sql, conn))
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Success");
            }
        }
        finally
        {
            conn.Close();
        }
    }
