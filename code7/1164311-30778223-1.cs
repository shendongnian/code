    string Command = "select TOP1 * from fees where admno = @admno ORDER BY receiptnumber DSEC";
    using (SqlConnection mConnection = new SqlConnection(ConnectionString))
    {
        mConnection.Open();
        using (SqlCommand cmd = new SqlCommand(Command, mConnection))
        {
            cmd.Parameters.Add(new MySqlParameter("@admno", temp));
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                reader.Read();
                TextBox1.Text = reader["admno"].ToString();
                TextBox2.Text = reader["receiptnumber"].ToString();
                TextBox3.Text = reader["name"].ToString();
                TextBox4.Text = reader["tutionfee"].ToString();
            }
        }
    }
