    private void btnInesrtDate_Click(object sender, EventArgs e)
    {
        string sql = "Insert Into BirthDates (Name, DateOfBirth) Values (@Name, @BirthDate)";
        string birthday = dataGridView1.CurrentRow.Cells[2].ToString();
        command.Parameters.AddWithValue("@Name", txtName.Text);
        command.Parameters.AddWithValue("@BirthDate", birthday);
        conn.Open();
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
