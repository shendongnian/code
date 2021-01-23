    con.Open();
    cmd = new SqlCommand(@"Select Room_Name From Rooms where room_name = @roomName", con);
    cmd.Parameters.Add("@roomName", SqlDbType.NVarChar, -1).Value = txtRoom.Text;
    rdr = cmd.ExecuteReader();
    if (rdr.Read())
    {
         roomname = rdr["Room_Name"].ToString();
    }
    else
    {
        MessageBox.Show("Room is invalid.");
        txtRoom.Focus();
    }
    rdr.Close();
    con.Close();
