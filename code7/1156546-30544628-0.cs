                var connection = new SqlConnection("ConnectionString");
                connection.Open();
                var command = new SqlCommand("SELECT id FROM Table WHERE id='" + textBox2.Text + "",connection);
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    textBox1.Text = reader["id"].ToString();
                }
                else
                {
                    ///No entry found
                }
                connection.Close();
