    bool insert()
    {
        try
        {
            Connection.Open();
            string query = "Insert into checkouts(cnic,medicine,next_trip) VALUES(@c, @m, @n)";
            SqlCommand command = new SqlCommand(query, Connection);
            command.Parameters.AddWithValue("@c", cnic_box.Text.Replace("-",""));
            command.Parameters.AddWithValue("@m", med_box.Text);
            command.Parameters.AddWithValue("@n",Convert.ToDateTime(date_box.Text).ToString("yyyy-MM-dd"));
            command.ExecuteNonQuery();
            Connection.Close();
            return true;
        }
        catch (Exception ex)
        {
            Connection.Close();
            return false;
        }
    }
