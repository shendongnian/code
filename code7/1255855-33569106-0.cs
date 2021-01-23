        using (MySqlConnection con = new MySqlConnection(yourConnectionString))
        {
            using (MySqlCommand cmd = new MySqlCommand("Storeprociduer", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SchoolID", SchoolID);
                using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    // Do something with results
                }
            }
        }
