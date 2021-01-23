    private void btn_Click(object sender, RoutedEventArgs e)
    {
        string connectionString = "server = localhost; database= test;Integrated Security = true";
        using(SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            using(SqlCommand cmd = new SqlCommand("SELECT * FROM table WHERE name LIKE '%' + @name + '%'")
            {
                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        if(Convert.ToInt32(reader["quantity").ToString()) > 0)
                        {
                            cmd.CommandText = "Update so set quantity where quantity = 0  And name Like '%' + @name + '%'";
                            cmd.Parameters.AddWithValue("@name", txt.Text);
                            cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            MessageBox.Show("There isn't any part left that you are looking for");
                        }
                    }
                    reader.Close();
                }
            }
        }
    }
