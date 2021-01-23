    private string connectionString = "Your connection string";
    private void cbListFirst_SetDataSource()
    {
        // Using block will automatically close connection when it's not used anymore
        using (var con = new SqlConnection(connectionString))
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"SELECT Id, Name
                                FROM dbo.FoodTypes";
            try
            {
                con.Open();
                var foodTypes = new List<FoodType>();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    // Fill items for first CheckedListBox DataSource
                    while (reader.Read())
                    {
                        foodTypes.Add(new FoodType()
                        {
                            Id = (int)reader["Id"],
                            Name = reader["Name"] as string
                        });
                    }
                }
                // Set first CheckedListBox DataSource
                cbListFirst.DataSource = foodTypes;
                cbListFirst.DisplayMember = "Name";
                cbListFirst.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                // Clear DataSource and handle error (should be improved)
                cbListFirst.DataSource = null;
                MessageBox.Show("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
