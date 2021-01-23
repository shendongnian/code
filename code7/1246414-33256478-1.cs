            string connectionString = "You connection string to database";
    
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                // Open the SqlConnection.
                con.Open();
                //
                // The following code uses an SqlCommand based on the SqlConnection.
                //
                using (SqlCommand command = new SqlCommand("select * from Personal_Details WHERE PersonID= " + personIDTextBox.Text, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Txt_FirstName.Text = (reader["FIRSTNAME"].ToString());
                    }
                }
            }
