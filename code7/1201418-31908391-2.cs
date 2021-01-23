            ....
            connection.Open();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if(reader.Read())
                {
                    if (reader["Id"].ToString() == textBox1.Text && 
                        reader["Password"].ToString() == textBox2.Text)
                    {
                        reader.Read();
                        MessageBox.Show("Hello!");
                        c=1;
                    }
                }
                ....
