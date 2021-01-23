        using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=E:\C #\InsertDeleteUpdate-Login\InsertDeleteUpdate-Login\Database1.mdf;Integrated Security=True"))
        using (SqlCommand command = new SqlCommand("select 1 from info where Id = @Id and Password = @Password", connection))
        {
            command.Parameters.Add("@Id", SqlDbType.NVarChar).Value = textBox1.Text;
            command.Parameters.Add("@Password", SqlDbType.NVarChar).Value = textBox2.Text;
            connection.Open();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if(reader.Read())
                {
                    MessageBox.Show("Hello!");
                }
                else
                {
                    MessageBox.Show("wrong id or password");
                }
            }
        }
