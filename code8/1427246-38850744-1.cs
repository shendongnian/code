    try {
        Connection.Open();
        string query = "Insert into checkouts(cnic,medicine,next_trip) VALUES(@c,@m,@n)";
        SqlCommand command = new SqlCommand(query, Connection);
        command.Parameters.AddWithValue("@c", cnic_box.Text.Replace("-",""));
        command.Parameters.AddWithValue("@m", med_box.Text);
        command.Parameters.AddWithValue("@n",Convert.ToDateTime(date_box.Text).ToString("yyyy-MM-dd"));
        Connection.Close();
        return (command.ExecuteNonQuery() > 0);
    }
    catch (Exception ex)
    {
        Connection.Close();
        return false;
    }
