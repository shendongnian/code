    if(listBox1.SelectedValue != null)
    {
        int userID = Convert.ToInt32(listBox1.SelectedValue);
        using (conn = new SqlConnection(connectionString))
        using (SqlCommand command = new SqlCommand("DELETE FROM myDatabase WHERE Id = @uid", conn))
        {
            conn.Open();
            command.Parameters.Add("@uid", MySqlDbType.Int32).Value = userID;
            command.ExecuteNonQuery();
        }
    }
