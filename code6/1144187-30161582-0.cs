    using (SqlCommand cmd =
                new SqlCommand("SELECT email, notify_if FROM notify WHERE jump_id = @jump_id", con))
                {
                    cmd.Parameters.AddWithValue("@jump_id", jumpid.Text);
                    SqlDataReader rd = cmd.ExecuteReader(); 
                    List<String> user = new List<String>(); 
                    List<int> ids = new List<int>();
                    while (rd.Read()) 
                    {
                        userAddre.Add((String)rd.GetValue(0));
                        ids.Add((int)rd.GetValue(1))
                    }
    if (userAddre.Count > 0) //if exists
                    {
    //do something
    }
            using (SqlCommand cmd =
                new SqlCommand("DELETE FROM notify WHERE notify_if = ", con))
            {
    //Here add some elements from ids list.
                cmd.Parameters.AddWithValue(????);
                cmd.ExecuteNonQuery();
            }
