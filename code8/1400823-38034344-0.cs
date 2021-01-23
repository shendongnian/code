    using (var connection = new SqlConnection(connectionString))
    {
        using (var cmd = new SqlCommand("SELECT * FROM Customers", connection))
        {
            connection.Open();
    
            using (var reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    MessageBox.Show("ROWS");
                }
                else
                {
                    MessageBox.Show("NO ROWS");
                }
            }
        }
    }
