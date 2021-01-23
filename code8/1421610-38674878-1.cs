       string str = <Example Above>;
        con.Open();
        MySqlCommand cmd = new MySqlCommand(str, con);
        cmd.Parameters.AddWithValue("?hospitalID", generalID.Text);
        cmd.Parameters.AddWithValue("?city", cityName.Text);
        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt); 
        con.Close();
