                using (SqlConnection connection = con)
            {
                SqlCommand command = new SqlCommand("SPSelcsclass", connection);  // select charge,shortclass from class where class=@class  
                command.Parameters.AddWithValue("class", "SLEEPER CLASS");
                connection.Open();
                SqlDataReader sdr = command.ExecuteReader();
                while(sdr.Read())
                {
                    lb11.Text = sdr["charge"].ToString();
                    lb2.Text = sdr["shortclass"].ToString();
                }
                connection.Close();
            }
