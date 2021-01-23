        using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=E:\C #\InsertDeleteUpdate-Login\InsertDeleteUpdate-Login\Database1.mdf;Integrated Security=True"))
        using (SqlCommand command = new SqlCommand("select * from info", connection))
        {
            connection.Open();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if(reader.Read())
                {
                    if (reader["Id"].ToString() == textBox1.Text && reader["Password"].ToString() == textBox2.Text)
                    {
                        MessageBox.Show("Hello!");
                        c=1;
                    }
                }
                if(c==0)
                    MessageBox.Show("wrong id or password");
            }
        }
