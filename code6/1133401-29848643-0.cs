    using (SqlConnection con = new SqlConnection("Your Connection String"))
        {
            using (SqlCommand cmd = new SqlCommand("Your Query", con))
            {
                con.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        StudentID = Convert.ToInt32(reader["Field you want to read here"]);
                        YourLabelId.Text += StudentID;
                    }
                }
            }
